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
    internal class ProgramController : BaseController
    {
        public static async Task<ControllerModifyData<models.Program>> CreateProgram(string name, string description)
        {
            ControllerModifyData<models.Program> returnData = new()
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
            if (string.IsNullOrWhiteSpace(name)) errors["name"] = "Name is required";
            if (string.IsNullOrWhiteSpace(description)) errors["description"] = "Description is required";
            if (!await Validator.IsProgramNameUnique(name)) errors["name"] = "Name already exists";

            if (errors.Count == 0)
            {
                ProgramDAO progDao = new();
                ReturnResult<models.Program> result = await progDao.Create(new models.Program
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

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                returnResult.Errors["permission"] = "Forbidden";
                returnResult.IsSuccess = false;

                return returnResult;
            }

            if (id < 0) returnResult.Errors["id"] = "ID is invalid";

            if (returnResult.Errors.Count == 0)
            {
                ProgramDAO progDao = new();
                returnResult.IsSuccess = await progDao.Remove(id.ToString());
            }

            return returnResult;
        }

        public static async Task<ControllerModifyData<models.Program>> UpdateProgram(int programId, string name, string description)
        {
            ControllerModifyData<models.Program> returnData = new()
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
            if (!await Validator.IsProgramNameUnique(name, programId.ToString())) errors["name"] = "Name already exists";
            if (programId < 0) errors["programId"] = "ID is invalid";
            if (string.IsNullOrWhiteSpace(name)) errors["name"] = "Name is required";
            if (string.IsNullOrWhiteSpace(description)) errors["description"] = "Description is required";

            // update if theres no error
            if (errors.Count == 0)
            {
                ProgramDAO progDao = new();

                // check if book exists
                ReturnResult<models.Program> program = await progDao.GetById(programId.ToString());

                if (!program.IsSuccess)
                {
                    errors["programId"] = "Program not found";
                    returnData.Errors = errors;
                    returnData.IsSuccess = isSuccess;
                    return returnData;
                }

                // proceed if book is found
                ReturnResult<models.Program> result = await progDao.Update(new models.Program
                {
                    ID = programId,
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

        public static async Task<ControllerModifyData<models.Program>> GetProgramById(int id)
        {
            ControllerModifyData<models.Program> returnData = new()
            {
                Result = default
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            // validate fields
            if (id < 0) errors["id"] = "ID is invalid";

            // is not librarian
            if (!await AuthGuard.HavePermission("LIBRARIAN"))
            {
                errors["permission"] = "Forbidden";
                returnData.Errors = errors;
                returnData.IsSuccess = false;

                return returnData;
            }

            if (errors.Count == 0)
            {
                ProgramDAO progDao = new();
                ReturnResult<models.Program> result = await progDao.GetById(id.ToString());

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

        public static async Task<ControllerAccessData<models.Program>> GetAllPrograms(int page = 1)
        {
            ControllerAccessData<models.Program> returnData = new()
            {
                Results = new List<models.Program>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (page <= 0) errors["page"] = "Invalid page";

            if (errors.Count == 0)
            {
                ProgramDAO progDao = new();
                ReturnResultArr<models.Program> result = await progDao.GetAll(page);

                isSuccess = result.IsSuccess;
                returnData.Results = result.Results;
                returnData.rowCount = result.rowCount;
            }

            returnData.Errors = errors;
            returnData.IsSuccess = isSuccess;
            return returnData;
        }

        public static async Task<ControllerAccessData<models.Program>> GetAllPrograms()
        {
            ControllerAccessData<models.Program> returnData = new()
            {
                Results = new List<models.Program>(),
                rowCount = 0
            };
            Dictionary<string, string> errors = new();
            bool isSuccess = false;

            if (errors.Count == 0)
            {
                ProgramDAO progDao = new();
                ReturnResultArr<models.Program> result = await progDao.GetAll();

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
