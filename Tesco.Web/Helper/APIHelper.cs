using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Tesco.Helper;
using Tesco.Model;

namespace Tesco.Web.Helper
{
    public class APIHelper
    {
        /// <summary>
        /// Assigning the property with HttpClient
        /// </summary>
        public static HttpClient Client;
        private static HttpClientHandler _handler;

        static APIHelper()
        {
            if (_handler == null) _handler = new HttpClientHandler
            {
                UseDefaultCredentials = true,
                PreAuthenticate = true,
                AllowAutoRedirect = true,
                ClientCertificateOptions = ClientCertificateOption.Automatic
            };

            if (Client == null) Client = new HttpClient(_handler, false);
        }

        public static HttpClient GetHttpClient(API apiUrl)
        {
            if (Client.BaseAddress == null)
            {
                Client.BaseAddress = new Uri(apiUrl.URL);
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.APPLICATIONJSON));
            }
            return Client;
        }
    }
}
