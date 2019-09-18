using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.SearchModels;
using WikiBookGetApi.Core.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// Main service 
        /// </summary>
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        /// <summary>
        /// Detail Search from Book Api 
        /// </summary>
        /// <param name="Author">Search parameter for author search</param>
        /// <param name="Title">Search parameter for Title search</param>
        /// <param name="Id">Search parameter for Id search</param>
        /// <returns>List of book filtered by search parameters</returns>
        [HttpGet]
        public ActionResult<IEnumerable<BookDTO>> GetBook(string Author, string Title, int Id)
        {
            if (string.IsNullOrWhiteSpace(Author) && string.IsNullOrWhiteSpace(Title) && Id == 0)
            {
                return Ok(bookService.GetAllBooks());
            }
            var searchParameter = new SearchParameterModel { Author = Author, Title = Title, Id = Id };
            var tempResult = bookService.GetBook(searchParameter);
            return tempResult.ToList();
        }
    }
}
