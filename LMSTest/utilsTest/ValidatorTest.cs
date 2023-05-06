using LibraryManagementSystemWF.utils;

namespace LMSTest
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void Should_Name_Is_Unique()
        {
            Assert.IsTrue(Validator.IsNameUnique("genres", "name", "horror genre"));
        }

        [TestMethod]
        public void Should_Be_Email()
        {
            Assert.IsTrue(
                !Validator.IsEmail("This is not a valid email!!")
                &&
                Validator.IsEmail("test@google.com")
                );
        }

        [TestMethod]
        public void Should_Be_Phone()
        {
            Assert.IsTrue(
                !Validator.IsPhone("+672314182768765247")
                &&
                Validator.IsPhone("+639100813695") // Not a real phone number
                );
        }

        [TestMethod]
        public void Should_Be_Name()
        {
            Assert.IsTrue(
                !Validator.IsName("makuletz69")
                &&
                Validator.IsName("Juan")
                );
        }

        [TestMethod]
        public void Should_Be_Username()
        {
            Assert.IsTrue(
                !Validator.IsUsername("AAAAHHHHHHH!!!!!!")
                &&
                Validator.IsUsername("coco_martin420")
                );
        }

        [TestMethod]
        public void Should_Be_Password()
        {
            Assert.IsTrue(
                !Validator.IsPassword("123")
                &&
                Validator.IsPassword("1234567890")
                );
        }

        [TestMethod]
        public void Should_Have_Copy()
        {
            Assert.IsTrue(Validator.IsCopyAvailable("A3B69499-7EC9-4B51-9BE7-E13840862733"));
        }
    }
}