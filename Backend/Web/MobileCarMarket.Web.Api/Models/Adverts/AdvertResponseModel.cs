namespace MobileCarMarket.Web.Api.Models.Adverts
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using Infrastructure.Mappings;
    using MobileCarMarket.Models;

    public class AdvertResponseModel: IMapFrom<Advert>, IHaveCustomMappings
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsNew { get; set; }

        public double Price { get; set; }

        public DateTime PublishDate { get; set; }

        public ICollection<string> ImagesUrls { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Advert, AdvertResponseModel>()
                .ForMember(ar => ar.ImagesUrls, opts => opts.MapFrom(a => a.ImagesData));
        }
    }
}