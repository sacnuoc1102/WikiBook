using System.Collections.Generic;
using WikiBookGetApi.Core.Models;

namespace WikiBookGetApi.Core.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();

        IEnumerable<Book> GetBooksByAuthor(string author);

    }
}
