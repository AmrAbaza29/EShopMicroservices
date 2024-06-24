using BuildingBlocks.CQRS;
using Catalog.API.DTOs;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.GetProduct
{
    public class GetProductsQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductsQuery, ProductResultDto>
    {
        public async Task<ProductResultDto> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().ToListAsync(cancellationToken);
            return new ProductResultDto(products);
        }
    }
}
