using CQRS.Common.Commands;
using CQRS.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.EF.Handlers
{
    public class ProductQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly ApplicationDbContext _context;

        public ProductQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}