using LibraryManagementSystemWF.dao;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystemWF.controllers
{
    internal class GenreController : BaseController
    {
        public static ControllerModifyData<Genre> CreateGenre(string name, string description)
        {
            ControllerModifyData<Genre> returnData = new ControllerModifyData<Genre>();
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
            if (string.IsNullOrWhiteSpace(name)) errors.Add("name", "Name is required");
            if (string.IsNullOrWhiteSpace(description)) errors.Add("description", "Description is required");
            if (!Validator.IsNameUnique("genres", "name", name)) errors.Add("name", "Name already exists");

            if (errors.Count == 0)
            {
                GenreDAO genreDao = new GenreDAO();
                ReturnResult<Genre> result = genreDao.Create(new Genre
                {
                    Name = name,
                    Description = description
                });

                isSuccess = result.IsSuccess;
                returnData.Result = result.Result;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static ControllerActionData RemoveById(int id)
        {
            ControllerActionData returnResult = new ControllerActionData();
            returnResult.Errors = new Dictionary<string, string>();
            returnResult.IsSuccess = false;

            // is not admin
            if (!AuthGuard.IsAdmin())
            {
                returnResult.Errors.Add("permission", "Forbidden");

                return returnResult;
            }

            if (returnResult.Errors.Count == 0)
            {
                GenreDAO genreDao = new GenreDAO();
                returnResult.IsSuccess = genreDao.Remove(id.ToString());
            }

            return returnResult;
        }

        public static ControllerModifyData<Genre> UpdateGenre(int genreId, string name, string description)
        {
            ControllerModifyData<Genre> returnData = new ControllerModifyData<Genre>();
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
            if (genreId < 0) errors.Add("genreId", "ID is invalid");
            if (string.IsNullOrWhiteSpace(name)) errors.Add("name", "Name is required");
            if (string.IsNullOrWhiteSpace(description)) errors.Add("description", "Description is required");
            if (!Validator.IsNameUnique("genres", "name", name)) errors.Add("name", "Name already exists");

            // update if theres no error
            if (errors.Count == 0)
            {
                GenreDAO genreDao = new GenreDAO();

                // check if book exists
                ReturnResult<Genre> genre = genreDao.GetById(genreId.ToString());

                if (!genre.IsSuccess)
                {
                    errors.Add("genreId", "Genre not found");
                    returnData.Errors = errors;
                    returnData.IsSuccess = isSuccess;
                    return returnData;
                }

                // proceed if book is found
                ReturnResult<Genre> result = genreDao.Update(new Genre
                {
                    ID = genreId,
                    Name = name,
                    Description = description
                });

                Console.WriteLine("RESULT: " + result.IsSuccess);
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

        public static ControllerModifyData<Genre> GetGenreById(int id)
        {
            ControllerModifyData<Genre> returnData = new ControllerModifyData<Genre>();
            returnData.Result = default(Genre);
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;

            // validate fields
            if (id < 0) errors.Add("id", "ID is invalid");

            if (errors.Count == 0)
            {
                GenreDAO genreDao = new GenreDAO();
                ReturnResult<Genre> result = genreDao.GetById(id.ToString());

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

        public static ControllerAccessData<Genre> GetAllGenres(int page = 1)
        {
            ControllerAccessData<Genre> returnData = new ControllerAccessData<Genre>();
            returnData.Results = new List<Genre>();
            Dictionary<string, string> errors = new Dictionary<string, string>();
            bool isSuccess = false;
            returnData.rowCount = 0;

            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0)
            {
                GenreDAO genreDao = new GenreDAO();
                ReturnResultArr<Genre> result = genreDao.GetAll(page);

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
