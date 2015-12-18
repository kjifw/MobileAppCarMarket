namespace MobileCarMarket.Http
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    public class HttpAuth
    {
        private string apiUrl;

        public HttpAuth(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public async Task<HttpResult> Login(string email, string password)
        {
            using (var client = new HttpClient())
            {
                var formsData = new Dictionary<string, string>
                {
                    { "Username", email },
                    { "Password", password },
                    { "grant_type", "password" }
                };

                var encodedFormsData = new FormUrlEncodedContent(formsData);
                var response = await client.PostAsync(this.apiUrl, encodedFormsData);

                if(response.StatusCode != HttpStatusCode.OK)
                {
                    return new HttpResult(false);
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                var responseBodyDeserialized = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseBody);

                if(responseBodyDeserialized.ContainsKey("access_token") == false)
                {
                    return new HttpResult(false);
                }

                return new HttpResult(true, responseBodyDeserialized["access_token"]);
            }
        }

        public async Task<HttpResult> Register(string email, string password, string confirmPassword)
        {
            using (var client = new HttpClient())
            {
                var formsData = new Dictionary<string, string>
                {
                    { "Email", email },
                    { "Password", password },
                    { "ConfirmPassword", confirmPassword }
                };

                var encodedFormsData = new FormUrlEncodedContent(formsData);

                var response = await client.PostAsync(this.apiUrl, encodedFormsData);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return new HttpResult(false);
                }
            }

            return new HttpResult(true);
        }
    }
}
