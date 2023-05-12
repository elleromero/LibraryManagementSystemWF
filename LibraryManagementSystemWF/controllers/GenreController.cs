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
        public static async Task<ControllerModifyData<Genre>> CreateGenre(string name, string description)
        {
            ControllerModifyData<Genre> returnData = new()
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
            if (string.IsNullOrWhiteSpace(name)) errors.Add("name", "Name is required");
            if (string.IsNullOrWhiteSpace(description)) errors.Add("description", "Description is required");
            if (!await Validator.IsNameUnique("genres", "name", name)) errors.Add("name", "Name already exists");

            if (errors.Count == 0)
            {
                GenreDAO genreDao = new();
                ReturnResult<Genre> result = await genreDao.Create(new Genre
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

        public static async Task<ControllerActionData> RemoveById(int id)
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
                GenreDAO genreDao = new();
                returnResult.IsSuccess = await genreDao.Remove(id.ToString());
            }

            return returnResult;
        }

        public static async Task<ControllerModifyData<Genre>> UpdateGenre(int genreId, string name, string description)
        {
            ControllerModifyData<Genre> returnData = new()
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
            if (genreId < 0) errors.Add("genreId", "ID is invalid");
            if (string.IsNullOrWhiteSpace(name)) errors.Add("name", "Name is required");
            if (string.IsNullOrWhiteSpace(description)) errors.Add("description", "Description is required");
            if (!await Validator.IsNameUnique("genres", "name", name)) errors.Add("name", "Name already exists");

            // update if theres no error
            if (errors.Count == 0)
            {
                GenreDAO genreDao = new();

                // check if book exists
                ReturnResult<Genre> genre = await genreDao.GetById(genreId.ToString());

                if (!genre.IsSuccess)
                {
                    errors.Add("genreId", "Genre not found");
                    returnData.Errors = errors;
                    returnData.IsSuccess = isSuccess;
                    return returnData;
                }

                // proceed if book is found
                ReturnResult<Genre> result = await genreDao.Update(new Genre
                {
                    ID = genreId,
                    Name = name,
                    Description = description
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

        public static async Task<ControllerModifyData<Genre>> GetGenreById(int id)
        {
            ControllerModifyData<Genre> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // validate fields
            if (id < 0) errors.Add("id", "ID is invalid");

            if (errors.Count == 0)
            {
                GenreDAO genreDao = new();
                ReturnResult<Genre> result = await genreDao.GetById(id.ToString());

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

        public static async Task<ControllerAccessData<Genre>> GetAllGenres(int page = 1)
        {
            ControllerAccessData<Genre> returnData = new()
            {
                Results = new List<Genre>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (page <= 0) errors.Add("page", "Invalid page");

            if (errors.Count == 0)
            {
                GenreDAO genreDao = new();
                ReturnResultArr<Genre> result = await genreDao.GetAll(page);

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
