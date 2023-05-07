using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;

namespace LMSTest
{
    [TestClass]
    public class BookControllerTest
    {
        [TestMethod]
        public async void Should_Create_Book()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<Book> res = await BookController.CreateBook(
                1,
                "HTML Semantics",
                "K. Heart",
                "freecodecamp",
                new DateTime(2003, 1, 23),
                "978-3-16-148410-0"
                );

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async void Should_Get_Book_By_Id()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<Book> res = await BookController.GetBookById("47298E60-74EA-4F20-AAF2-55FAC9797492");

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async void Should_Update_Book()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<Book> res = await BookController.UpdateBook(
                "47298E60-74EA-4F20-AAF2-55FAC9797492",
                1,
                "HTML Semantic",
                "Kevin Bacon",
                "freecodecamp",
                new DateTime(2003, 1, 23),
                "978-3-16-148410-0"
                );

            Console.WriteLine(res.IsSuccess);
            Console.WriteLine(res.Result?.Author);
        }

        [TestMethod]
        public async void Should_Get_All_Books()
        {
            await AuthController.SignIn("admin", "password");
            ControllerAccessData<Book> res = await BookController.GetAllBooks();

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async void Should_Remove_By_Id()
        {
            await AuthController.SignIn("admin", "password");
            ControllerActionData res = await BookController.RemoveById("A21D93F9-1AC2-4B77-9543-8B38C286DA29");

            Assert.IsTrue(res.IsSuccess);
        }
    }
}