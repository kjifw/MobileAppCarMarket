namespace MobileCarMarket.Http
{
    public class HttpResult
    {
        public HttpResult()
        {

        }

        public HttpResult(bool succeeded)
        {
            this.Succeeded = succeeded;
        }

        public HttpResult(bool succeeded, string result)
            : this(succeeded)
        {
            this.Result = result;
        }

        public bool Succeeded { get; set; }
        
        public string Result { get; set; } 
    }
}
