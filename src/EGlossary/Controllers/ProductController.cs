using EGlossary.Domain.Entities;
using EGlossary.Service.Features.ProductsFeatures.Queries;
using EGlossary.Service.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EGlossary.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Product")]
    [ApiVersion("1.0")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(typeof(List<ProductEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQuery());
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            var response = await _mediator.Send(productDto);
            return StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductEntity), (int)HttpStatusCode.OK)]
        [Route("{Id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var response = await _mediator.Send(new GetProductByIdQuery { Id = Id });
            return Ok(response);
        }
    }
}