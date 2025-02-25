using AutoMapper;
using Talapate.APi.Dtos;
using Talapate.Core.Entities;

namespace Talapate.APi.Helper
{
    public class productPictureUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public productPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) 
            {
                return $"{_configuration["ApiBaseUrl"]}{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
