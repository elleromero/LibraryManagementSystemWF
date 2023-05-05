using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;

namespace LMSTest
{
    [TestClass]
    public class CopyControllerTest
    {
        [TestMethod]
        public void Should_Create_Copies()
        {
            AuthController.SignIn("admin", "password");
            ControllerModifyData<Copy> res = CopyController.CreateCopies(
                "A5BDF027-CE17-4F76-B95A-82D2FB7640E8",
                12
                );
            Console.WriteLine(res.Result.Book.Genre.Name);
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_Get_Genre_By_Id()
        {
            ControllerModifyData<Genre> res = GenreController.GetGenreById(5);

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_Update_Genre()
        {
            AuthController.SignIn("admin", "password");
            ControllerModifyData<Genre> res = GenreController.UpdateGenre(5, "Embutido", "AAAAAHHHH");

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_Get_All_Genres()
        {
            ControllerAccessData<Genre> res = GenreController.GetAllGenres();

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public void Should_Remove_By_Id()
        {
            AuthController.SignIn("admin", "password");
            ControllerActionData res = GenreController.RemoveById(7);

            Assert.IsTrue(res.IsSuccess);
        }
    }
}