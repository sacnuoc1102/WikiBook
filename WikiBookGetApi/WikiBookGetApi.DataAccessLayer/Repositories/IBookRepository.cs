using System;
using System.Collections.Generic;
using System.Text;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.SearchModels;
using WikiBookGetApi.DataAccessLayer.Models;

namespace WikiBookGetApi.DataAccessLayer.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<BookDTO> GetBook(Func<BookDTO, bool> filterCondition);
    }
}
