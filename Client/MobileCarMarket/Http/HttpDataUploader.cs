namespace MobileCarMarket.Http
{
    using System;
    using System.Threading.Tasks;
    using Windows.Storage.Streams;
    using Windows.Web.Http;
    using Windows.Web.Http.Headers;

    public class HttpDataUploader
    {
        private string apiUrl;
        private string token;

        public HttpDataUploader(string apiUrl, string token)
        {
            this.apiUrl = apiUrl;
            this.token = token;
        }

        public async Task<HttpResult> UploadJsonData(string jsonData)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.token);
                var response = await client.PostAsync(new Uri(this.apiUrl, UriKind.Absolute), new HttpStringContent(jsonData, UnicodeEncoding.Utf8, "application/json"));

                if(response.StatusCode != HttpStatusCode.Created)
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

        public async Task<HttpResult> UploadImage(IRandomAccessStream imageStream)
        {
            using (var client = new HttpClient())
            {
                HttpMultipartFormDataContent form = new HttpMultipartFormDataContent();
                form.Add(new HttpStreamContent(imageStream));

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + this.token);
                var response = await client.PostAsync(new Uri(this.apiUrl, UriKind.Absolute), form);

                if(response.StatusCode != HttpStatusCode.Created)
                {
                    return new HttpResult()
                    {
                        Succeeded = false
                    };
                }

                return new HttpResult()
                {
                    Succeeded = true
                };
            }
        }
    }
}
