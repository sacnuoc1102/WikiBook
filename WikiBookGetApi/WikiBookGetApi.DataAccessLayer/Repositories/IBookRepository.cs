using System;
using System.Collections.Generic;
using System.Text;
using WikiBookGetApi.Core.SearchModels;
using WikiBookGetApi.DataAccessLayer.Models;

namespace WikiBookGetApi.DataAccessLayer.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetBooksByAuthor(string author);
        Book GetBookById(int id);
        IEnumerable<Book> GetBooksByTitle(string title);
        IEnumerable<Book> GetBook(SearchParameterModel searchParameter);
    }
}
