namespace MobileCarMarket.Http
{
    using System;
    using System.Threading.Tasks;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;

    public class HttpDataDownloader
    {
        private string apiUrl;
        private string token;

        public HttpDataDownloader(string apiUrl, string token)
        {
            this.apiUrl = apiUrl;
            this.token = token;
        }

        public async Task<HttpResult> DownloadJsonData()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.token);
                var response = await client.GetAsync(new Uri(this.apiUrl, UriKind.Absolute));
                
                if (response.StatusCode != HttpStatusCode.Ok)
                {
                    return new HttpResult()
                    {
                        Succeeded = false
                    };
                }

                return new HttpResult()
                {
                    Succeeded = true,
                    Result = await response.Content.ReadAsStringAsync()
                };
            }
        }
    }
}
