using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Helpers
{
    public class MainHttpClient
    {
        public string PostHttpClientRequest(string requestEndPoint, object content)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                //client.BaseAddress = new Uri(MConfig.WebApiBaseUrl);

                client.DefaultRequestHeaders.Clear();

                //if (AdminUCtxt != null)
                //{
                //    //Authorization Token for POST
                //    client.DefaultRequestHeaders.Add("Authorization", "bearer " + AdminUCtxt.Tokens.Token);
                //    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", UCtxt.Token);
                //}

                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.PostAsJsonAsync(requestEndPoint, content).Result;
                //Res.Content = new StringContent()
                return Res.Content.ReadAsStringAsync().Result;

            }

        }

        public string GetHttpClientRequest(string requestEndPoint)
        {

            using (var client = new HttpClient())
            {
                //Passing service base url  
                //client.BaseAddress = new Uri(MConfig.WebApiBaseUrl);

                client.DefaultRequestHeaders.Clear();

                //if (AdminUCtxt != null)
                //{
                //    //Authorization Token for GET
                //    client.DefaultRequestHeaders.Add("Authorization", "bearer " + AdminUCtxt.Tokens.Token);
                //}

                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.GetAsync(requestEndPoint).Result;
                return Res.Content.ReadAsStringAsync().Result;
            }
        }

    }
}
