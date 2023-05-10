﻿using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
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
            string coverPath = "",
            string sypnosis = "No sypnosis available"
            )
        {
            ControllerModifyData<Book> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.IsAdmin())
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            if (!await Validator.IsNameUnique("books", "title", title)) errors.Add("title", "Title already exists");
            if (!await Validator.IsGenreIdValid(genreId)) errors.Add("genreId", "ID is invalid");
            if (string.IsNullOrWhiteSpace(title)) errors.Add("title", "Title is required");
            if (string.IsNullOrWhiteSpace(author)) errors.Add("author", "Author is required");
            if (string.IsNullOrWhiteSpace(publisher)) errors.Add("publisher", "Publisher is required");
            if (!Validator.IsDateBeforeOrOnPresent(publicationDate)) errors.Add("publicationDate", "Datetime must be before or on the present date");
            if (!Validator.IsValidISBN(isbn)) errors.Add("isbn", "Invalid ISBN. Make sure the ISBN is in ISBN-10 or ISBN-13 format");

            if (errors.Count == 0)
            {
                BookDAO bookDao = new();
                ReturnResult<Book> result = await bookDao.Create(new Book
                {
                    Title = title,
                    Sypnosis = sypnosis,
                    Author = author,
                    Cover = coverPath,
                    Publisher = publisher,
                    PublicationDate = publicationDate,
                    ISBN = isbn,
                    Genre = new Genre
                    {
                        ID = genreId
                    }
                });

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;
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
            string coverPath = "",
            string sypnosis = "No sypnosis available"
            )
        {
            ControllerModifyData<Book> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // is not admin
            if (!await AuthGuard.IsAdmin())
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            if (!await Validator.IsNameUnique("books", "title", title)) errors.Add("title", "Title already exists");
            if (!await Validator.IsGenreIdValid(genreId)) errors.Add("genreId", "ID is invalid");
            if (string.IsNullOrWhiteSpace(title)) errors.Add("title", "Title is required");
            if (string.IsNullOrWhiteSpace(author)) errors.Add("author", "Author is required");
            if (string.IsNullOrWhiteSpace(publisher)) errors.Add("publisher", "Publisher is required");
            if (!Validator.IsDateBeforeOrOnPresent(publicationDate)) errors.Add("publicationDate", "Datetime must be before or on the present date");
            if (!Validator.IsValidISBN(isbn)) errors.Add("isbn", "Invalid ISBN. Make sure the ISBN is in ISBN-10 or ISBN-13 format");

            // update if theres no error
            if (errors.Count == 0)
            {
                BookDAO bookDao = new();

                // check if book exists
                ReturnResult<Book> book = await bookDao.GetById(bookId);

                if (!book.IsSuccess)
                {
                    errors.Add("bookId", "Book not found");

                    returnData.Errors = errors;
                    returnData.IsSuccess = isSuccess;
                    return returnData;
                }

                // proceed if book is found
                ReturnResult<Book> result = await bookDao.Update(new Book
                {
                    ID = new Guid(bookId),
                    Title = title,
                    Sypnosis = sypnosis,
                    Author = author,
                    Cover = coverPath,
                    Publisher = publisher,
                    PublicationDate = publicationDate,
                    ISBN = isbn,
                    Genre = new Genre
                    {
                        ID = genreId
                    }
                });

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

        public static async Task<ControllerModifyData<Book>> GetBookById(string id)
        {
            ControllerModifyData<Book> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // validate fields
            if (string.IsNullOrWhiteSpace(id)) errors.Add("id", "ID is invalid");

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

            if (page <= 0) errors.Add("page", "Invalid page");

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

            // is not admin
            if (!await AuthGuard.IsAdmin())
            {
                returnResult.Errors.Add("permission", "Forbidden");

                return returnResult;
            }

            if (returnResult.Errors.Count == 0)
            {
                BookDAO bookDao = new();
                returnResult.IsSuccess = await bookDao.Remove(id);
            }

            return returnResult;
        }

        
    }
}
