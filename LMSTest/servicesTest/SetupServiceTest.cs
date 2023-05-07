using LibraryManagementSystemWF.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSTest.servicesTest
{
    [TestClass]
    public class SetupServiceTest
    {
        [TestMethod]
        public async void Should_Setup()
        {
            Assert.IsTrue(await SetupService.Ready());
        }
    }
}
