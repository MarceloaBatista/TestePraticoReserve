using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid.Service
{
    public static class ClientHttp
    {

        public static async Task<HttpResponseMessage> Get(string Uri)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(Uri);
            var result = httpClient.GetAsync(Uri).Result;

            return result;
        }
        
    }
}
