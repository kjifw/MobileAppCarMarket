namespace MobileCarMarket.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int AdvertId { get; set; }

        public virtual Advert Advert { get; set; }

        public int UserId { get; set; }

        public virtual User Authro { get; set; }

        public string Text { get; set; }
    }
}
