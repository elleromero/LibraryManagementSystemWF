using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;

namespace LMSTest
{
    [TestClass]
    public class LoanControllerTest
    {
        [TestMethod]
        public async Task Should_Borrow_Book()
        {
            ControllerModifyData<Loan> res = await LoanController.BorrowBook(
                "AD6399DD-B343-45F8-8640-B41415F8932F",
                "1D7A0664-2E78-407F-B0CD-C3CE50D3FD24",
                new DateTime(2023, 12, 23)
                );

            foreach (KeyValuePair<string, string> err in res.Errors)
            {
                Console.WriteLine(err.Value);
            }
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Return_Book()
        {
            ControllerModifyData<Loan> res = await LoanController.ReturnBook(
                "AD6399DD-B343-45F8-8640-B41415F8932F",
                "BC5B6036-4352-4786-8D90-6C8BEE5949B0"
                );

            foreach (KeyValuePair<string, string> err in res.Errors)
            {
                Console.WriteLine(err.Value);
            }
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Get_All_Loans()
        {
            ControllerAccessData<Loan> res = await LoanController.GetAllLoans(
                "AD6399DD-B343-45F8-8640-B41415F8932F"
                );

            Console.WriteLine(res.Results.Count);
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Get_Loan()
        {
            ControllerModifyData<Loan> res = await LoanController.GetLoanById(
                "DACCE262-A2DD-409B-8626-E69ECA802AA9"
                );

            Console.WriteLine(res.Result?.User.Username);
            Assert.IsTrue(res.IsSuccess);
        }
    }
}