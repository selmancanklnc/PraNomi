using Newtonsoft.Json;
using PraNomi.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PraNomi.Services
{
    public static class ProductServices
    {
        private static ProductResponseModel responseModel;

        public static ProductResponseModel ProductList(int page, int size)
        {



            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.pranomi.com/Product?size=10&page=1"))
                {
                    request.Version = HttpVersion.Version11;

                    request.Headers.TryAddWithoutValidation("Authorization", "Basic cFZHZENQZTlUSlh6bkExaHZGTEdKdVBOWDVrc3hFcGZaM09SUEpiZ3VJQzpUMzJLRjVJNENaaWQ4YU9j");

                    //   request.Content = new StringContent(JsonConvert.SerializeObject());

                    using (var response = httpClient.SendAsync(request).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseString = response.Content.ReadAsStringAsync().Result;
                            responseModel = JsonConvert.DeserializeObject<ProductResponseModel>(responseString);


                        }

                    }
                }
            }

            return responseModel;
        }

    }
}
