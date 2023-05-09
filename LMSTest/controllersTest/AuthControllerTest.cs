using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;
using LibraryManagementSystemWF.services;
using LibraryManagementSystemWF.utils;

namespace LMSTest
{
    [TestClass]
    public class AuthControllerTest
    {
        [TestMethod]
        public async Task Shoulld_Register()
        {
            ControllerModifyData<User> res = await AuthController.Register(
                "test_omineko",
                "password",
                "elle",
                "romero",
                "Bancal St.",
                "+639100813695",
                "romero@gmail.com"
                );

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_SignIn()
        {
            ControllerModifyData<User> res = await AuthController.SignIn("admin", "password");
            
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_Logout()
        {
            ControllerActionData res = AuthController.LogOut();
            Assert.IsTrue(res.IsSuccess);

        }
    }
}