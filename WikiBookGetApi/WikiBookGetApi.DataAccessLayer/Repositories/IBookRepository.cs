using System;
using System.Collections.Generic;
using System.Text;
using WikiBookGetApi.Core.Models;

namespace WikiBookGetApi.DataAccessLayer.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Books> GetAllBooks();

        IEnumerable<Books> GetBooksByAuthor(string author);
    }
}
