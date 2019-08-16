using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WikiBook.WebClient.Models;

namespace WikiBook.WebClient.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var books = GetBooksFromApi();
            return View(books);
        }

        [HttpPost]
        public IActionResult Index(string author)
        {
            var books = GetBookByAuthor(author);
            return View(books);
        }

        /// <summary>
        /// Get the books list from database through the API
        /// </summary>
        /// <returns>List of books</returns>
        private List<BookModel> GetBooksFromApi()
        {
            try
            {
                var resultList = new List<BookModel>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://localhost:44333/api/Book")
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<BookModel>>();
                            readResult.Wait();
                            resultList = readResult.Result;
                        }
                    });
                getDataTask.Wait();
                return resultList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        /// <summary>
        /// Search for books whose from author name
        /// </summary>
        /// <param name="author"></param>
        /// <returns>list of books by author</returns>
        private List<BookModel> GetBookByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException(nameof(author));
            }
            try
            {
                var resultList = new List<BookModel>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync("https://localhost:44333/api/Book/" + author.ToString())
                    .ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readResult = result.Content.ReadAsAsync<List<BookModel>>();
                            readResult.Wait();
                            resultList = readResult.Result;
                        }
                    });
                getDataTask.Wait();
                return resultList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}