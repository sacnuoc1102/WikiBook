using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WikiBookGetApi.Core.Models;
using WikiBookGetApi.Core.Services;

namespace WikiBookGetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        // GET: api/Book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return bookService.GetAllBooks().ToList();
        }


        // GET: api/Book/authorName
        [HttpGet("{author}", Name ="Get")]
        public ActionResult<IEnumerable<Book>> GetBookByAuthor(string author)
        {
            return bookService.GetBooksByAuthor(author).ToList();
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

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
