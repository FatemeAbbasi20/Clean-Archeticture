using Clean_Arch.Domain.ProductsAgg;
using Clean_Arch.Domain.Shared;

namespace Presentation_WebApi.ViewModels.Products
{
    public class ProductViewModel
    {
        public Money Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public DateTime CreationTime { get; set; }
        public long Id { get; set; }
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();
    }
}
