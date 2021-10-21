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
    public static class CustomerServices
    {

        private static CustomerResponseModel responseModel;

        public static CustomerResponseModel CustomerList(CustomerSearchModel customerSearchModel)
        {



            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), $"https://api.pranomi.com/Customer/{customerSearchModel.customerSearchQuery}?page={customerSearchModel.Page}&size={customerSearchModel.Size}"))
                {
                    request.Version = HttpVersion.Version11;

                    request.Headers.TryAddWithoutValidation("Authorization", "Basic cFZHZENQZTlUSlh6bkExaHZGTEdKdVBOWDVrc3hFcGZaM09SUEpiZ3VJQzpUMzJLRjVJNENaaWQ4YU9j");

                    //   request.Content = new StringContent(JsonConvert.SerializeObject());

                    using (var response = httpClient.SendAsync(request).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseString = response.Content.ReadAsStringAsync().Result;
                            responseModel = JsonConvert.DeserializeObject<CustomerResponseModel>(responseString);


                        }

                    }
                }
            }

            return responseModel;
        }

    }
}
