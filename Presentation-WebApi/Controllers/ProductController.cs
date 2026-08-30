using AutoMapper;
using Clean_Arch.Application.Products.Create;
using Clean_Arch.Application.Products.Edit;
using Clean_Arch.Query.Models;
using Clean_Arch.Query.Products.Dtos;
using Clean_Arch.Query.Products.GetProductById;
using Clean_Arch.Query.Products.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation_WebApi.ViewModels;
using Presentation_WebApi.ViewModels.Products;
using System.Runtime.CompilerServices;

namespace Presentation_WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
          private readonly IMediator _mediator;
       private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
      
        [HttpGet]
        [Authorize]
        public async Task<List<ProductViewModel>> GetProducts()
        {
            var products= await _mediator.Send(new GetProductListQuery());
           return _mapper.Map<List<ProductViewModel>>(products).AddLinks();
          
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> GetProductById(long id)
        {
            var product= await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                return NotFound("ProductNotFound");
            }
           return _mapper.Map<ProductViewModel>(product).AddLinks();
            //var url = Url.Action(nameof(EditProduct), "Product", Request.Scheme);
            //return Created(url, result);
         
        }


        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductCommand command)
        {
          var result=  await _mediator.Send(command);
            var url = Url.Action(nameof(GetProductById), "Product",new {id= result },Request.Scheme);
           return Created(url, result);
        }
        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProducts(long id)
        {
            
            return Ok(id);
        }
     
    }
}
