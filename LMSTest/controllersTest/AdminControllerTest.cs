using Isopoh.Cryptography.Argon2;
using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using System.Diagnostics;

namespace LMSTest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public async Task Should_Create_Admin()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<User> admin = await AdminController.CreateAdmin(
                "admin_tanuki",
                "password",
                "admin",
                "romero",
                "717 Apitong st.",
                "+63910083695"
                );

            Assert.IsTrue(admin.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Update_User()
        {
            bool isUpdated = false;

            await AuthController.SignIn("admin", "password");
            ControllerModifyData<User> admin = await AdminController.CreateAdmin(
                "admin_999",
                "password",
                "admin",
                "romero",
                "717 Apitong st.",
                "+63910083695",
                "gibberish@test.com"
                );

            if (admin.IsSuccess && admin.Result != null)
            {
                ControllerModifyData<User> adminUpd = await AdminController.UpdateUser(
                    admin.Result.ID.ToString(),
                    "admin_updated",
                    "password",
                    "admin",
                    "romero",
                    "717 Apitong st.",
                    "+63910083695",
                    "password",
                    "normal@email.com"
                    );

                foreach (KeyValuePair<string, string> err in adminUpd.Errors)
                {
                    Console.WriteLine(err.Value);
                }
                isUpdated = adminUpd.IsSuccess;
            }

            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public async Task Should_GetById()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<User> res = await AdminController.GetUserById("993CC885-4EA2-4210-8468-7B81C7F0DE2F");

            Console.WriteLine(res.Result?.Username);
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_GetAllUsers()
        {
            await AuthController.SignIn("admin", "password");
            ControllerAccessData<User> res = await AdminController.GetAllUsers();

            Console.WriteLine(res.Results.Count);
            Console.WriteLine(res.rowCount);
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_RemoveById()
        {
            await AuthController.SignIn("admin", "password");
            ControllerActionData res = await AdminController.RemoveById("43BEA7F9-6DFA-46E0-829F-68FD2F78E14F", "password");

            Assert.IsTrue(res.IsSuccess);
        }
    }
}