using LibraryManagementSystemWF.controllers;
using LibraryManagementSystemWF.models;

namespace LMSTest
{
    [TestClass]
    public class CopyControllerTest
    {
        [TestMethod]
        public async Task Should_Create_Copies()
        {
            await AuthController.SignIn("admin", "password");
            ControllerModifyData<Copy> res = await CopyController.CreateCopies(
                "1D7A0664-2E78-407F-B0CD-C3CE50D3FD24",
                5
                );

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Get_Copy_By_Id()
        {
            ControllerModifyData<Copy> res = await CopyController.GetCopyById("9A49991B-1946-4092-BE74-4E4CEB1F2A70");

            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Get_All_Copies()
        {
            ControllerAccessData<Copy> res = await CopyController.GetAllCopies();

            Assert.IsTrue(res.Results.Count > 0);
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Get_All_Copies_With_Books()
        {
            ControllerAccessData<Copy> res = await CopyController.GetAllCopiesWithBook("1D7A0664-2E78-407F-B0CD-C3CE50D3FD24");

            Assert.IsTrue(res.Results.Count > 0);
            Assert.IsTrue(res.IsSuccess);
        }

        [TestMethod]
        public async Task Should_Remove_By_Id()
        {
            await AuthController.SignIn("admin", "password");
            ControllerActionData res = await CopyController.RemoveById("9A49991B-1946-4092-BE74-4E4CEB1F2A70");

            Assert.IsTrue(res.IsSuccess);
        }

    }
}