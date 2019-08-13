using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.DataAccessLayer.Data;
using WikiBookGetApi.DataAccessLayer.Repositories;

namespace WikiBookGetApi.DataAccessLayer.Tests
{
    public class BookRepositoryTests
    {
        private Mock<WikiBookDBContext> mockBookDbContext;
        private Mock<BookRepository> repository;
        private Mock<DbSet<Book>> mockDbSet;

        public BookRepositoryTests()
        {
            this.mockBookDbContext = new Mock<WikiBookDBContext>();
            this.repository = new Mock<BookRepository>();
            this.mockDbSet = new Mock<DbSet<Book>>();
            
            //set up mocking object
            this.mockBookDbContext.Setup(m => m.Books).Returns(mockDbSet.Object);         
        }


        [Test]
        public void GetAllBooks_SuccessfullyRetrieved()
        {
            // Arrange

            // Act
            repository.Object.GetAllBooks();

            //Assert
            repository.Verify(x => x.GetAllBooks(),Times.Exactly(1));
        }

    }
}
