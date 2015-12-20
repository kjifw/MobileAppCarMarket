namespace MobileCarMarket.Web.Api.Models.Adverts
{
    using System.ComponentModel.DataAnnotations;

    public class CreateAdvertRequestModel
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public bool IsNew { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }
    }
}