using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WikiBook.WebClient.Models;

namespace WikiBook.WebClient.Business
{
    public class BookApiHelper
    {

        private readonly IConfiguration config;
        public BookApiHelper(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// Get the books list from database through the API
        /// </summary>
        /// <returns>List of books</returns>
        public List<BookModel> GetBooksFromApi()
        {
            try
            {
                var connectionstring = config["GetAllBookApiConnectionString"];
                var resultList = new List<BookModel>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync(connectionstring)
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
        public List<BookModel> GetBookByAuthor(string author)
        {
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException(nameof(author));
            }
            try
            {
                var connectionstring = config["SearchByAuthorConnectionString"];
                var resultList = new List<BookModel>();
                var client = new HttpClient();
                var getDataTask = client.GetAsync(connectionstring + author.ToString())
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
