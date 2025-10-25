using EGlossary.Domain.Entities;
using EGlossary.Service.Features.OrderFeatures.Commands;
using EGlossary.Service.Features.OrderFeatures.Queries;
using EGlossary.Service.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace EGlossary.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Order")]
    [ApiVersion("1.0")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Create([FromBody] OrderDto orderModel)
        {
            var response = await _mediator.Send(orderModel);
            return StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<OrderEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllOrderQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetOrderByIdQuery { Id = id });
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteOrderCommandHandler { Id = id });
            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Update(int id, OrderDto updateOrderModel)
        {
            var response = await _mediator.Send(updateOrderModel);
            return StatusCode((int)HttpStatusCode.NoContent, response);
        }
    }
}