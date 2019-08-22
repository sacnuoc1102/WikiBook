using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.SearchModels;
using WikiBookGetApi.Core.Services;

namespace WikiBookGetApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : ApiController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        // GET: api/Book

        //[HttpGet]
        //public ActionResult<IEnumerable<Book>> GetAllBooks()
        //{
        //    return bookService.GetAllBooks().ToList();
        //}

        //[HttpGet("{id:int}")]
        //public ActionResult<Book> GetBookById(int id)
        //{
        //    if (id <= 0)
        //    {
        //        throw new ArgumentOutOfRangeException(nameof(id));
        //    }
        //    return bookService.GetBookById(id);
        //}

        //// GET: api/Book/authorName
        //[Route("")]
        //public ActionResult<IEnumerable<Book>> GetBookByAuthor(string author)
        //{
        //    if (string.IsNullOrWhiteSpace(author))
        //    {
        //        throw new ArgumentNullException(nameof(author));
        //    }
        //    return bookService.GetBooksByAuthor(author).ToList();
        //}

        //[Route("")]
        //public ActionResult<IEnumerable<Book>> GetBookByTitle(string title)
        //{
        //    if (string.IsNullOrEmpty(title))
        //    {
        //        return BadRequest("title can not be empty");
        //    }
        //    return bookService.GetBooksByTitle(title).ToList();
        //}

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetBook(SearchParameterModel searchParameter)
        {
            return Ok(bookService.GetBook(searchParameter).ToList());
        }
        //// GET: api/Book/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //// PUT: api/Book/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
