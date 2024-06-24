using BuildingBlocks.CQRS;
using Catalog.API.DTOs;
using Catalog.API.Exceptions;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Products.GetProductById
{
    public class GetProductByIdQueryHandler(IDocumentSession session)
        : IQueryHandler<GetProductByIdQuery, ProductByIdDto>
    {
        public async Task<ProductByIdDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await session
                .LoadAsync<Product>(request.Id, cancellationToken) 
                ?? throw new ProductNotFoundException(request.Id);

            return new ProductByIdDto(product);
        }
    }
}
