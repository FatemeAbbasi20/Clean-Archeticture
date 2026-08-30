using Clean_Arch.Query.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace Presentation_WebApi.ViewModels.Products
{
    public static class ProductLinkGenerator
    {
         public static ProductViewModel AddLinks(this ProductViewModel viewmodel)
        {
            var ProductUrl = "https://localhost:7163/Product";
            var link = new List<LinkDto>()
            {
               new LinkDto(ProductUrl,"UpdateProduct",HttpMethods.Put),
               new LinkDto($"{ProductUrl } /{viewmodel.Id }","DeleteProduct",HttpMethods.Delete)

            };
             viewmodel.Links.AddRange(link);
            return viewmodel;
        }

        public static List<ProductViewModel> AddLinks(this List<ProductViewModel> viewModel)
        {
   
            var ProductUrl = "https://localhost:7127/Product";
            viewModel.ForEach(item =>
            {
                var link = new List<LinkDto>()
                {

                    new LinkDto(ProductUrl,"UpdateProduct",HttpMethods.Put),
                    new LinkDto($"{ProductUrl}/{item.Id}","DeleteProduct",HttpMethods.Delete)
                };


                item.Links.AddRange(link);
            });
            return viewModel; 
        }




    }
}
