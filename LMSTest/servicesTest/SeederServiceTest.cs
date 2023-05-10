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
    public class SeederServiceTest
    {
        [TestMethod]
        public async void Should_Create_DB()
        {
           Assert.IsTrue(await SeederService.CreateDatabase());
        }
        public async void Should_Create_Tables()
        {
            Assert.IsTrue(await SeederService.CreateInitialTables());
        }
    }
}
