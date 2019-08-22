using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WikiBook.WebClient.Business;
using WikiBook.WebClient.Models;

namespace WikiBook.WebClient.Controllers
{
    public class BookController : Controller
    {
        private readonly BookApiHelper bookApiHelper;

        public BookController(IConfiguration config)
        {
            bookApiHelper = new BookApiHelper(config);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = this.bookApiHelper.GetBooksFromApi();
            return View(books);
        }

        [HttpPost]
        public IActionResult Index(string author)
        {
            var books = this.bookApiHelper.GetBookByAuthor(author);
            return View(books);
        }
    }
}