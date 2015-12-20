namespace MobileCarMarket.LocalDb.Models
{
    using SQLite.Net.Cipher.Interfaces;
    using SQLite.Net.Cipher.Model;

    public class Token : IModel
    {
        public string Id { get; set; }

        [Secure]
        public string Data { get; set; }
    }
}
