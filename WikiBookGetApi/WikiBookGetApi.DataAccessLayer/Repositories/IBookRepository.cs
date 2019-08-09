﻿using System;
using System.Collections.Generic;
using System.Text;
using WikiBookGetApi.Core.Models;

namespace WikiBookGetApi.DataAccessLayer.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();

        IEnumerable<Book> GetBooksByAuthor(string author);
    }
}
