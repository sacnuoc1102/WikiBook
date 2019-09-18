using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.DataAccessLayer.Models;
using WikiBookGetApi.DataAccessLayer.Repositories;

namespace WikiBookGetApi.DataAccessLayer.Tests
{
    public class BookRepositoryTests
    {
        private Mock<WikiBookDBContext> mockBookDbContext;
        private BookRepository repository;
        private Mock<DbSet<Book>> mockDbSet;
        private IMapper mapper;

        public BookRepositoryTests()
        {
            this.mockBookDbContext = new Mock<WikiBookDBContext>();
            this.repository = new BookRepository(mockBookDbContext.Object, mapper);
            this.mockDbSet = new Mock<DbSet<Book>>();
            this.mockDbSet.Object.Add(new Book { Authors = "mock" });
            //set up mocking object

        }


        [Test]
        public void GetAllBooks_SuccessfullyRetrieved()
        {
            // Arrange
            this.mockBookDbContext.Setup(m => m.Books).Returns(mockDbSet.Object);

            // Act
            var temp = repository.GetBook(book => true);

            //Assert
            Assert.NotNull(temp);
        }

        [Test]
        public void GetAllBooks_EmptyDBObject_FailRetrieved()
        {
            // Arrange           
            var author = "mock";
            // Act
            var temp = repository.GetBook(book => book.Authors == author);

            //Assert
            Assert.;
        }
    }
}
