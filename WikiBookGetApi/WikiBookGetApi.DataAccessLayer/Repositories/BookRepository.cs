using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Utilities;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.SearchModels;
using WikiBookGetApi.DataAccessLayer.Models;

namespace WikiBookGetApi.DataAccessLayer.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly WikiBookDBContext context;
        private readonly IMapper mapper;

        public BookRepository(WikiBookDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public BookRepository()
        {
        }

        //public IEnumerable<Book> GetBook(SearchParameterModel searchParameter)
        //{
        //    IEnumerable<Book> tempResult = context.Books;

        //    if (!string.IsNullOrWhiteSpace(searchParameter.Author))
        //    {
        //        tempResult = context.Books.Where(t => t.Authors.Contains(searchParameter.Author));
        //    }
        //    if (!string.IsNullOrWhiteSpace(searchParameter.Title))
        //    {
        //        tempResult = tempResult.Where(b => b.Title.Contains(searchParameter.Title));
        //    }
        //    if (searchParameter.Id > 0)
        //    {
        //        tempResult = tempResult.Where(b => b.BookId == searchParameter.Id);
        //    }
        //    return tempResult;
        //}

        public IEnumerable<BookDTO> GetBook(Func<BookDTO,bool> filterCondition)
        {
            IEnumerable<Book> tempResult = context.Books;
            Func<Book, bool> mappedCondition = mapper.Map<Func<Book, bool>>(filterCondition);
            tempResult = context.Books.Where(mappedCondition);
            return mapper.Map<IEnumerable<BookDTO>>(tempResult);
        }
    }
}
