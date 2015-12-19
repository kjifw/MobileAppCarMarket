namespace MobileCarMarket.LocalDb.Models
{
    using SQLite.Net.Cipher.Interfaces;
    using SQLite.Net.Cipher.Model;

    public class Photo : IModel
    {
        public string Id { get; set; }

        [Secure]
        public byte[] Data { get; set; }

        [Secure]
        public double Longitude { get; set; }

        [Secure]
        public double Latitude { get; set; }
    }
}
