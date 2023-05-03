using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;

namespace LMSTest
{
    [TestClass]
    public class StatusControllerTest
    {
        [TestMethod]
        public void Should_Get_All_Statuses()
        {
            ControllerAccessData<Status> res = StatusController.GetAllStatuses();

            Console.WriteLine(res.Results.Count);
            Assert.IsTrue(res.IsSuccess);
        }
    }
}