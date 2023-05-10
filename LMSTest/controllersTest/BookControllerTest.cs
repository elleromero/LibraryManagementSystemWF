using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;

namespace LMSTest
{
    [TestClass]
    public class BookControllerTest
    {
        [TestMethod]
        public async Task Should_Create_Book()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<Book> res = await BookController.CreateBook(
                3,
                "HTML Semantics Vol. 21",
                "Jane Doe",
                "freecodecamp",
                new DateTime(2003, 1, 23),
                "978-3-16-148410-0"
                );

            foreach (KeyValuePair<string, string> err in res.Errors)
            {
                Console.WriteLine(err.Value);
            }
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Get_Book_By_Id()
        {
            ControllerModifyData<Book> res = await BookController.GetBookById("5C71A9E2-9038-462A-993B-E622A5717660");

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Update_Book()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<Book> res = await BookController.UpdateBook(
                "1D7A0664-2E78-407F-B0CD-C3CE50D3FD24",
                1,
                "HTML Semantic Third Edition",
                "Kevin Bacon",
                "freecodecamp",
                new DateTime(2003, 1, 23),
                "978-3-16-148410-0"
                );

            Console.WriteLine(res.IsSuccess);
            Console.WriteLine(res.Result?.Author);
        }

        [TestMethod]
        public async Task Should_Get_All_Books()
        {
            ControllerAccessData<Book> res = await BookController.GetAllBooks();

            Console.WriteLine(res.Results.Count);
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Remove_By_Id()
        {
            await AuthController.SignIn("admin", "password");
            ControllerActionData res = await BookController.RemoveById("5C71A9E2-9038-462A-993B-E622A5717660");

            Assert.IsTrue(res.IsSuccess);
        }
    }
}