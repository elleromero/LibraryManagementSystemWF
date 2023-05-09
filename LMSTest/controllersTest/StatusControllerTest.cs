using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;

namespace LMSTest
{
    [TestClass]
    public class StatusControllerTest
    {
        [TestMethod]
        public async Task Should_Get_All_Statuses()
        {
            ControllerAccessData<Status> res = await StatusController.GetAllStatuses();

            Console.WriteLine(res.Results.Count);
            Assert.IsTrue(res.IsSuccess);
        }
    }
}