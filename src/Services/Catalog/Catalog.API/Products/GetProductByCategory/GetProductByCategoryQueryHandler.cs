using BuildingBlocks.CQRS;
using Catalog.API.DTOs;
using Catalog.API.Exceptions;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.GetProductByCategory
{
    public class GetProductByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger) 
        : IQueryHandler<GetProductByCategoryQuery, ProductByCategoryDto>
    {
        public async Task<ProductByCategoryDto> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
                .Where(p => p.Category.Contains(request.Category))
                .ToListAsync(cancellationToken)
                ?? throw new ProductNotFoundException(Guid.NewGuid());

            return new ProductByCategoryDto(products);
        }
    }
}
