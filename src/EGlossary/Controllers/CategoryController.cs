using EGlossary.Domain.Entities;
using EGlossary.Service.Features.CategoryFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EGlossary.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Category")]
    [ApiVersion("1.0")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoryEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCategory()
        {
            var response = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(response);
        }
    }
}