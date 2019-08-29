using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Index(string author,string title, int? bookId)
        {     
            if(!ModelState.IsValid)
            {
                return BadRequest("something went wrong");
            }
            var books = this.bookApiHelper.GetBookByFilter(author, title, bookId);
            //if(books == null)
            //{
            //    return BadRequest("there is no result with search values");
            //}
            return View(books);
        }

        [HttpGet]
        public IActionResult BookDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookDetail(int? id)
        {
            var selectedBook = this.bookApiHelper.GetBookByFilter(null, null, Convert.ToInt32(id)).FirstOrDefault();
            return View(selectedBook);
        }

        [HttpPost]
        public IActionResult LikeABook()
        {
            var temp = User.Identity.Name.ToString();
            return View((object)temp);
        }

        [HttpGet]
        public IActionResult LikedBookOverview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LikedBookOverview(string userIdentity)
        {
            return View();
        }
    }
}