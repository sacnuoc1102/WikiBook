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
        public IList<BookModel> GetBooksFromApi()
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
        /// 
        /// </summary>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<BookModel> GetBookByFilter(string author, string title, int? id)
        {
            var connectionstring = config["SearchByAuthorConnectionString"];

            if (!string.IsNullOrWhiteSpace(author))
            {
                connectionstring += "&Author=" + author;
            }
            if (!string.IsNullOrWhiteSpace(title))
            {
                connectionstring += "&Title=" + title; 
            }
            if (id > 0)
            {
                connectionstring += "&Id=" + id;         
            }
            // if author not null >> add  the query /book?author=author
            //  $(api/Book? {0} 
            try
            {               
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



    }
}
