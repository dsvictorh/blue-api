using AutoMapper;
using BlueAPI.Data.Models;
using BlueAPI.DataTransferObjects;
using BlueAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            this._mapper = mapper;
            this._productService = productService;
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> FindProduct(int id)
        {
            Product? product = await this._productService.GetProductById(id);
            if(product == null)
            { 
                return HttpErrors.NotFound("Product does not exist");
            }

            APIResponse response = new()
            { 
                Data = this._mapper.Map<Product, GetProductDTO>(product)
            };

            //CALCULAR DISCOUNT Y FINAL PRICE

            return response;
        }
    }
}
