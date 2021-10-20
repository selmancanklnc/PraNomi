    using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PraNomi.Model.Login;
using PraNomi.Models.Login;
using Xamarin.Essentials;

namespace PraNomi.Services
{
    public class ApiServices
    {
        private static ApiServices _ServiceClientInstance;
        public static ApiServices ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new ApiServices();
                return _ServiceClientInstance;
            }
        }

        private JsonSerializer _serializer = new JsonSerializer();
        private HttpClient client;


        public ApiServices()
        {
            client = new HttpClient();
            //Change your base address here
            client.BaseAddress = new Uri("https://api.pranomi.com");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<LoginApiResponseModel> AuthenticateUserAsync(string phonenumber, string password)
        {
            try
            {
                LoginApiRequestModel loginRequestModel = new LoginApiRequestModel()
                {
                    userName = phonenumber,
                    password = password

                };
                var content = new StringContent(JsonConvert.SerializeObject(loginRequestModel), Encoding.UTF8, "application/json");
                //Change your base address tail part here and post it. 
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.pranomi.com/Login"))
                    {
                        request.Content = content;
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        return JsonConvert.DeserializeObject<LoginApiResponseModel>(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
