using System.Collections.Generic;
using WikiBookGetApi.Core.Models;

namespace WikiBookGetApi.Core.Services
{
    public interface IBookService
    {
        IEnumerable<Books> GetAllBooks();

        IEnumerable<Books> GetBooksByAuthor(string author);

    }
}
