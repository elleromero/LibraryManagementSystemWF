using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManagementSystemWF.controllers
{
    internal class LoanController : BaseController
    {
        public static async Task<ControllerModifyData<Loan>> BorrowBook(string bookId)
        {
            ControllerModifyData<Loan> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();
            DateTime dueDate = DateTime.Now.AddDays(EnvService.GetBorrowTimeDays());

            // is not librarian
            if (!await AuthGuard.HavePermission("USER"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            if (string.IsNullOrWhiteSpace(userId))
            {
                errors.Add("auth", "Please login");
            } else
            {
                if (await BookGuard.IsPastDue(userId)) errors.Add("book", "You currently have books borrowed past due");
            }
            if (string.IsNullOrWhiteSpace(bookId)) errors.Add("bookId", "ID is invalid");
            if (dueDate.Date < DateTime.Now.Date) errors.Add("dueDate", "Invalid due date");
            if (!await Validator.IsCopyAvailable(bookId)) errors.Add("bookId", "No available copies for this book");

            if (errors.Count == 0)
            {
                LoanDAO loanDao = new();
                ReturnResult<Loan> result = await loanDao.Create(new Loan
                {
                    Copy = new Copy
                    {
                        Book =
                        {
                            ID = new Guid(bookId)
                        }
                    },
                    User = new User
                    {
                        ID = new Guid(userId)
                    },
                    DateBorrowed = DateTime.Now,
                    DateDue = dueDate
                });

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }
    
        public static async Task<ControllerModifyData<Loan>> ReturnBook(string loanId)   
        {
            ControllerModifyData<Loan> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();

            // is not librarian
            if (!await AuthGuard.HavePermission("USER"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validation
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("auth", "Please login");
            if (string.IsNullOrWhiteSpace(loanId)) errors.Add("loanId", "ID is invalid");

            // update if theres no error
            if (errors.Count == 0 && userId != null)
            {
                LoanDAO loanDao = new();

                // proceed if book is found
                ReturnResult<Loan> result = await loanDao.Update(new Loan
                {
                    ID = new Guid(loanId),
                    User = new User
                    {
                        ID = new Guid(userId)
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

        public static async Task<ControllerAccessData<Loan>> ReturnDueBooks(List<string> loans, double cash, double totalAmount)
        {
            ControllerAccessData<Loan> returnData = new()
            {
                Results = new List<Loan>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("auth", "Please login");
            if (loans.Count <= 0) errors.Add("loans", "Loans required");
            if (cash < totalAmount) errors.Add("cash", "Insufficient Cash");

            if (errors.Count == 0 && userId != null)
            {
                LoanDAO loanDao = new();
                ReturnResultArr<Loan> result = await loanDao.ReturnAll(loans);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerModifyData<Loan>> GetLoanById(string id)
        {
            ControllerModifyData<Loan> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // validate fields
            if (string.IsNullOrWhiteSpace(id)) errors.Add("id", "ID is invalid");

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            if (errors.Count == 0)
            {
                LoanDAO loanDao = new();
                ReturnResult<Loan> result = await loanDao.GetById(id);

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

        public static async Task<ControllerAccessData<Loan>> GetAllBorrowedBooks(int page = 1)
        {
            ControllerAccessData<Loan> returnData = new()
            {
                Results = new List<Loan>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();

            // is not user
            if (!await AuthGuard.HavePermission("USER"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("auth", "Please login");
            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0 && userId != null)
            {
                LoanDAO loanDao = new();
                ReturnResultArr<Loan> result = await loanDao.GetAllLoans(page, new Loan
                {
                    User = new User
                    {
                        ID = new Guid(userId)
                    }
                });

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<Loan>> GetAllBorrowedBooksPastDue(string targetUserId)
        {
            ControllerAccessData<Loan> returnData = new()
            {
                Results = new List<Loan>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();
            Console.WriteLine(await AuthGuard.HavePermission("USER"));
            Console.WriteLine(await AuthGuard.HavePermission("LIBRARIAN"));

            // validate
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("auth", "Please login");

            // is user or librarian
            if (!await AuthGuard.HavePermission("USER") || !await AuthGuard.HavePermission("LIBRARIAN"))
            {
                if (errors.Count == 0 && userId != null)
                {
                    LoanDAO loanDao = new();
                    ReturnResultArr<Loan> result = await loanDao.GetAllLoans(null, new Loan
                    {
                        User = new User
                        {
                            ID = new Guid(targetUserId)
                        }
                    }, true);

                    isSuccess = result.IsSuccess;
                    returnData.Results = result.Results;
                    returnData.rowCount = result.rowCount;
                }
            }
            else
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }


            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<Loan>> GetAllLoans(int page = 1)
        {
            ControllerAccessData<Loan> returnData = new()
            {
                Results = new List<Loan>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("auth", "Please login");
            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0 && userId != null)
            {
                LoanDAO loanDao = new();
                ReturnResultArr<Loan> result = await loanDao.GetAll(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<Loan>> Search(string keyword, int page = 1)
        {
            ControllerAccessData<Loan> returnData = new()
            {
                Results = new List<Loan>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;
            string? userId = AuthService.getSignedUser()?.ID.ToString();

            // is not user
            if (!await AuthGuard.HavePermission("USER"))
            {
                errors.Add("permission", "Forbidden");
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            // validate
            if (string.IsNullOrWhiteSpace(userId)) errors.Add("auth", "Please login");
            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0 && userId != null)
            {
                LoanDAO loanDao = new();
                ReturnResultArr<Loan> result = await loanDao.GetSearchResults(userId, keyword, page);

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
