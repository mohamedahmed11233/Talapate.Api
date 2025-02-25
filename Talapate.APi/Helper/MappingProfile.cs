using AutoMapper;
using Talapate.APi.Dtos;
using Talapate.Core.Entities;

namespace Talapate.APi.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
               .ForMember(x => x.Brand, o => o.MapFrom(d => d.Brand.Name))
               .ForMember(x => x.Cataegory, o => o.MapFrom(d => d.Cataegory.Name))
               .ForMember(x => x.PictureUrl, o => o.MapFrom<productPictureUrlResolver>());
               
        }
    }
}
