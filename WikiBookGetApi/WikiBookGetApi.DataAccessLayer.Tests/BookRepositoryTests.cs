﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private BookRepository repository;
        private Mock<DbSet<Book>> mockDbSet;

        public BookRepositoryTests()
        {
            this.mockBookDbContext = new Mock<WikiBookDBContext>();
            this.repository = new BookRepository(mockBookDbContext.Object);
            this.mockDbSet = new Mock<DbSet<Book>>();
            this.mockDbSet.Object.Add(new Book {Authors = "mock"});
            //set up mocking object

        }


        [Test]
        public void GetAllBooks_SuccessfullyRetrieved()
        {
            // Arrange
            this.mockBookDbContext.Setup(m => m.Books).Returns(mockDbSet.Object);
            
            // Act
            var temp = repository.GetAllBooks();

            //Assert
            Assert.NotNull(temp);
        }

        [Test]
        public void GetAllBooks_EmptyDBObject_FailRetrieved()
        {
            // Arrange           

            // Act
            var temp = repository.GetAllBooks();

            //Assert
            Assert.IsNull(temp);
        }
    }
}
