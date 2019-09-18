using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WikiBook.WebClient.Models;

namespace WikiBook.WebClient.Business
{
    public class IdentityHelper
    {
        private readonly IConfiguration config;

        public IdentityHelper(IConfiguration config)
        {
            this.config = config;
        }

        public IList<BookModel> GetUserLikedBooks(string userIdentity)
        {
            if (string.IsNullOrWhiteSpace(userIdentity))
            {
                throw new ArgumentNullException(nameof(userIdentity));      
            }
            try
            {
                var connectionstring = config["GetUserLikedBookConnectionString"];
                connectionstring += userIdentity;
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
