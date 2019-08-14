using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WikiBook.Web.Models;

namespace WikiBook.Web.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var books = GetBooksFromApi();
            return View(books);
        }

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
    }
}