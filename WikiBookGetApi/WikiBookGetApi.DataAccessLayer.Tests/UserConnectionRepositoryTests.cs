using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;
using WikiBookGetApi.DataAccessLayer.Repositories;

namespace WikiBookGetApi.DataAccessLayer.Tests
{
    [TestFixture]
    public class UserConnectionRepositoryTests
    {
        private UserConnectionRepository userRepo;

        [SetUp]
        public void SetUp()
        {
            userRepo = new UserConnectionRepository();
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t\r\n")]
        public void GetUserLikedBooks_NullParameter_GiveArgumentNullError(string param)
        {
            // Assert
            var ex = Assert.Throws<ArgumentNullException>(() => userRepo.GetUserLikedBooks(param));
            Assert.That(ex.Message, Is.EqualTo("Value cannot be null.\r\nParameter name: UserIdentity"));
        }


        [Test]
        public void GetUserLikedBooks_NotNullParameter_GiveNoError()
        {
            var ex = userRepo.GetUserLikedBooks("blabla");
            Assert.IsTrue(true);
        }

    }
}
