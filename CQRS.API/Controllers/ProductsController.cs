using CQRS.Common.Commands;
using CQRS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace YourApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _mediator.Send(new GetAllProductsQuery());
        }
        [HttpPost]
        public async Task<Product> Create([FromBody] CreateProductCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}