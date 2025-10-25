using EGlossary.Domain.Entities;
using EGlossary.Service.Features.CustomerFeatures.Commands;
using EGlossary.Service.Features.CustomerFeatures.Queries;
using EGlossary.Service.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EGlossary.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Customer")]
    [ApiVersion("1.0")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(CustomerDto customerModel)
        {
            var response = await _mediator.Send(customerModel);
            return StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CustomerEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCustomerQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var response = await _mediator.Send(new GetCustomerByIdQuery { Id = id });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var response = await _mediator.Send(new DeleteCustomerCommandHandler { Id = id });
            return Ok(response);
        }
    }
}