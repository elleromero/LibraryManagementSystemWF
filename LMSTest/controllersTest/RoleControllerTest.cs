using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;

namespace LMSTest
{
    [TestClass]
    public class RoleControllerTest
    {
        [TestMethod]
        public void Should_Get_All_Roles()
        {
            ControllerAccessData<Role> res = RoleController.GetAllRoles();

            Console.WriteLine(res.Results.Count);
            Assert.IsTrue(res.IsSuccess);
        }
    }
}