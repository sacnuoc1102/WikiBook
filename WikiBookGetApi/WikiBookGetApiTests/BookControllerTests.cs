using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WikiBookGetApi.Controllers;
using WikiBookGetApi.Core.Services;

namespace WikiBookGetApiTests
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController bookController;
        private Mock<IBookService> mockBookService;
        

        [SetUp]
        public void SetUp()
        {
            mockBookService = new Mock<IBookService>();
            bookController = new BookController(mockBookService.Object);
        }


        [Test]
        public void GetBookByTitle_CorrectTitleFormat_Success()
        {
           // Arange


           // Act

           // Asert
        }
    }
}
