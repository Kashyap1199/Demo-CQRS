using MediatR;
using CQRS.Domain.Models;

namespace CQRS.Common.Commands
{
    /// <summary>
    /// Create product command.
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Price"></param>
    public record CreateProductCommand(string Name, decimal Price) : IRequest<Product>;
}