namespace MobileCarMarket.Web.Api.Models.Adverts
{
    using System;

    using AutoMapper;

    using MobileCarMarket.Models;
    using MobileCarMarket.Web.Api.Infrastructure.Mappings;

    public class ListedAdvertResponseModel : IMapFrom<Advert>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsNew { get; set; }

        public double Price { get; set; }

        public DateTime PublishDate { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Advert, ListedAdvertResponseModel>()
                .ForMember(la => la.ImageUrl, opts => opts.MapFrom(a => a.FirstImageData != null ? a.FirstImageData.Url : null));
        }
    }
}