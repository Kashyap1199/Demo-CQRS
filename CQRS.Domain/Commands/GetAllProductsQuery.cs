using CQRS.Domain.Models;
using MediatR;

namespace CQRS.Common.Commands
{
    /// <summary>
    /// Get all products query.
    /// </summary>
    public record GetAllProductsQuery() : IRequest<List<Product>>;
}