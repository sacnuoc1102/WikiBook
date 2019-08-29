using System.Collections.Generic;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.SearchModels;

namespace WikiBookGetApi.Core.Services
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAllBooks();

        IEnumerable<BookDTO> GetBooksByAuthor(string author);

        BookDTO GetBookById(int id);

        IEnumerable<BookDTO> GetBooksByTitle(string title);

        IEnumerable<BookDTO> GetBook(SearchParameterModel searchParameter);
    }
}
