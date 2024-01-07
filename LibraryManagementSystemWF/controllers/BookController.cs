﻿using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystemWF.controllers
{
    internal class BookController : BaseController
    {

        public static async Task<ControllerModifyData<Book>> CreateBook(
            int genreId,
            string title,
            string author,
            string publisher,
            DateTime publicationDate,
            string isbn,
            string copyright,
            int sourceId,
            int copies = 1,
            decimal price = 0,
            string coverPath = "",
            string sypnosis = "No sypnosis available",
            int editionNum = 1,
            string editionStr = ""
            )
        {
            ControllerModifyData<Book> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            Config config = new();
            int maxCopies = config.maxCopies;
            decimal maxPrice = config.maxPrice;
            if (!await Validator.IsBookTitleUnique(title)) errors["title"] = "Title already exists";
            if (!await Validator.IsGenreIdValid(genreId)) errors["genreId"] = "Genre is invalid";
            if (!await Validator.IsSourceIdValid(sourceId)) errors["sourceId"] = "Source is invalid";
            if (!await Validator.IsISBNUnique(isbn)) errors["isbn"] = "ISBN was already registered";
            if (string.IsNullOrWhiteSpace(title)) errors["title"] = "Title is required";
            if (string.IsNullOrWhiteSpace(author)) errors["author"] = "Author is required";
            if (string.IsNullOrWhiteSpace(publisher)) errors["publisher"] = "Publisher is required";
            if (!Validator.IsDateBeforeOrOnPresent(publicationDate)) errors["publicationDate"] = "Datetime must be before or on the present date";
            if (!Validator.IsValidISBN(isbn)) errors["isbn"] = "Invalid ISBN. Make sure the ISBN is in ISBN-10 or ISBN-13 format";
            if (!(copies > 0 && copies <= maxCopies)) errors["copies"] = $"Should at least have a single copy and should not exceed {maxCopies} copies";
            if (price > maxPrice || price < 0) errors["price"] = "Invalid amount";
            if (editionNum < 1) errors["editionNum"] = "Invalid number";

            if (errors.Count == 0)
            {
                BookDAO bookDao = new();
                ReturnResult<Book> result = await bookDao.Create(new Book
                {
                    BookMetadata = new BookMetadata
                    {
                        Title = title,
                        Sypnosis = string.IsNullOrWhiteSpace(sypnosis) ? "No sypnosis available" : sypnosis,
                        Author = author,
                        Cover = coverPath,
                        Publisher = publisher,
                        PublicationDate = publicationDate,
                        ISBN = isbn,
                        Copyright = copyright.Trim(),
                        EditionNumber = editionNum,
                        EditionStr = editionStr,
                        Genre = new Genre
                        {
                            ID = genreId
                        }
                    },
                    AvailableCopies = copies,
                }, price, sourceId);

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;

                if (result.IsSuccess)
                {
                    User? signedUser = AuthService.getSignedUser();
                    if (signedUser != null)
                    {
                        // log history
                        ActivityLogger.Log($"{signedUser.Username} created book '{title}'", signedUser.ID, ActivityTypeEnum.BOOK_OPERATION);
                    }

                }
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerModifyData<Book>> UpdateBook(
            string bookId,
            int genreId,
            string title,
            string author,
            string publisher,
            DateTime publicationDate,
            string isbn,
            string copyright,
            string coverPath = "",
            string sypnosis = "No sypnosis available",
            int editionNum = 1,
            string editionStr = ""
            )
        {
            ControllerModifyData<Book> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            if (string.IsNullOrWhiteSpace(bookId)) errors["bookId"] = "Book ID is required";
            if (!await Validator.IsGenreIdValid(genreId)) errors["genreId"] = "ID is invalid";
            if (!await Validator.IsISBNUnique(isbn, bookId)) errors["isbn"] = "ISBN was already registered";
            if (string.IsNullOrWhiteSpace(title)) errors["title"] = "Title is required";
            if (string.IsNullOrWhiteSpace(author)) errors["author"] = "Author is required";
            if (string.IsNullOrWhiteSpace(publisher)) errors["publisher"] = "Publisher is required";
            if (!Validator.IsDateBeforeOrOnPresent(publicationDate)) errors["publicationDate"] = "Datetime must be before or on the present date";
            if (!Validator.IsValidISBN(isbn)) errors["isbn"] = "Invalid ISBN. Make sure the ISBN is in ISBN-10 or ISBN-13 format";
            if (editionNum < 1) errors["editionNum"] = "Invalid number";

            // update if theres no error
            if (errors.Count == 0)
            {
                BookDAO bookDao = new();

                // check if book exists
                ReturnResult<Book> book = await bookDao.GetById(bookId);

                if (!book.IsSuccess)
                {
                    errors["bookId"] = "Book not found";

                    returnData.Errors = errors;
                    returnData.IsSuccess = isSuccess;
                    return returnData;
                }

                // proceed if book is found
                ReturnResult<Book> result = await bookDao.Update(new Book
                {
                    ID = new Guid(bookId),
                    BookMetadata = new BookMetadata
                    {
                        Title = title,
                        Sypnosis = string.IsNullOrWhiteSpace(sypnosis) ? "No sypnosis available" : sypnosis,
                        Author = author,
                        Cover = coverPath,
                        Publisher = publisher,
                        PublicationDate = publicationDate,
                        ISBN = isbn,
                        Copyright = copyright.Trim(),
                        EditionNumber = editionNum,
                        EditionStr = editionStr,
                        Genre = new Genre
                        {
                            ID = genreId
                        }
                    }
                });

                isSuccess = result.IsSuccess;
                if (isSuccess && result.Result != null)
                {
                    returnData.Result = result.Result;

                    User? signedUser = AuthService.getSignedUser();
                    if (signedUser != null)
                    {
                        // log history
                        ActivityLogger.Log($"{signedUser.Username} updated book '{book.Result.BookMetadata.Title}' to '{title}'", signedUser.ID, ActivityTypeEnum.BOOK_OPERATION);
                    }
                }
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerModifyData<Book>> GetBookById(string id)
        {
            ControllerModifyData<Book> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // validate fields
            if (string.IsNullOrWhiteSpace(id)) errors["id"] = "ID is invalid";

            if (errors.Count == 0)
            {
                BookDAO bookDao = new();
                ReturnResult<Book> result = await bookDao.GetById(id);

                isSuccess = result.IsSuccess;
                if (isSuccess && result.Result != null)
                {
                    returnData.Result = result.Result;
                }
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<Book>> GetAllBooks(int page = 1)
        {
            ControllerAccessData<Book> returnData = new()
            {
                Results = new List<Book>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                BookDAO bookDao = new();
                ReturnResultArr<Book> result = await bookDao.GetAll(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerActionData> RemoveById(string id)
        {
            ControllerActionData returnResult = new()
            {
                Errors = new Dictionary<string, string>(),
                IsSuccess = false
            };

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                returnResult.Errors["permission"] = "Forbidden";

                return returnResult;
            }

            if (string.IsNullOrWhiteSpace(id)) returnResult.Errors["id"] = "ID is required";

            if (returnResult.Errors.Count == 0)
            {
                BookDAO bookDao = new();
                returnResult.IsSuccess = await bookDao.Remove(id);

                if (returnResult.IsSuccess)
                {
                    User? signedUser = AuthService.getSignedUser();
                    if (signedUser != null)
                    {
                        // log history
                        ActivityLogger.Log($"{signedUser.Username} removed a book", signedUser.ID, ActivityTypeEnum.BOOK_OPERATION);
                    }
                }
            }

            return returnResult;
        }

        public static async Task<ControllerAccessData<Book>> Search(string keyword, int page = 1)
        {
            ControllerAccessData<Book> returnData = new()
            {
                Results = new List<Book>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                BookDAO bookDao = new();
                ReturnResultArr<Book> result = await bookDao.GetSearchResults(keyword, page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }
    }
}
