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
        /// get all book from Book Api
        /// </summary>
        /// <returns> List of book </returns>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBook()
        {
            return this.bookService.GetAllBooks().ToList();
        }

        /// <summary>
        /// Detail Search from Book Api 
        /// </summary>
        /// <param name="Author">Search parameter for author search</param>
        /// <param name="Title">Search parameter for Title search</param>
        /// <param name="Id">Search parameter for Id search</param>
        /// <returns>List of book filtered by search parameters</returns>
        [HttpGet]
        [Route("api/Book")]
        public ActionResult<IEnumerable<Book>> GetBook(string Author, string Title, int Id)
        {
            var searchParameter = new SearchParameterModel { Author = Author, Title = Title, Id = Id };
            var tempResult = bookService.GetBook(searchParameter);
            if (tempResult == null)
            {
                return BadRequest("There aren't any result matches your search");
            }
            return tempResult.ToList();
        }
    }
}
