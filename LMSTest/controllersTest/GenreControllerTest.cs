using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;

namespace LMSTest
{
    [TestClass]
    public class GenreControllerTest
    {
        [TestMethod]
        public async Task Should_Create_Genre()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<Genre> res = await GenreController.CreateGenre("You", "Not a fiction");

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Get_Genre_By_Id()
        {
            ControllerModifyData<Genre> res = await GenreController.GetGenreById(5);

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Update_Genre()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<Genre> res = await GenreController.UpdateGenre(17, "Embutido", "AAAAAHHHH");

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Get_All_Genres()
        {
            ControllerAccessData<Genre> res = await GenreController.GetAllGenres();

            Assert.IsTrue(res.Results.Count > 0);
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Remove_By_Id()
        {
            await AuthController.SignIn("admin", "password");
            ControllerActionData res = await GenreController.RemoveById(17);

            Assert.IsTrue(res.IsSuccess);
        }
    }
}