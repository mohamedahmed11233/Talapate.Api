using Talapate.Core.Entities;

namespace Talapate.APi.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int BrandId { get; set; } //FK
        public string Brand { get; set; }


        public int CataegoryId { get; set; } //fk
        public string Cataegory { get; set; } //NP
    }
}
