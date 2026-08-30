using AutoMapper;
using Clean_Arch.Query.Models.Products;
using Presentation_WebApi.ViewModels.Products;

namespace Presentation_WebApi
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProductReadModel, ProductViewModel>().ReverseMap();
            
        }
    }
}
