using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.controllers
{
    internal class LoanController : BaseController
    {
        public static void BorrowBook(string userId, string bookId)
        {
            ControllerModifyData<Book> returnData = new ControllerModifyData<Book>();
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;

            // is not admin
            if (!AuthGuard.IsAdmin())
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("userId", "ID is invalid");
            if (string.IsNullOrWhiteSpace(bookId)) errors.Add("bookId", "ID is invalid");
            if (!Validator.IsCopyAvailable(bookId)) errors.Add("bookId", "No available books");

            if (errors.Count == 0)
            {
                BookDAO bookDao = new BookDAO();
                ReturnResult<Book> result = bookDao.Create(new Book
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
    }
}
