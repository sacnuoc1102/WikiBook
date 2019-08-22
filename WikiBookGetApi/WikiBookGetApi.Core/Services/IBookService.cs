using System.Collections.Generic;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.SearchModels;

namespace WikiBookGetApi.Core.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();

        IEnumerable<Book> GetBooksByAuthor(string author);

        Book GetBookById(int id);

        IEnumerable<Book> GetBooksByTitle(string title);

        IEnumerable<Book> GetBook(SearchParameterModel searchParameter);
    }
}
