using BuildingBlocks.CQRS;
using Catalog.API.DTOs;

namespace Catalog.API.Products.GetProductById
{
    public class GetProductByIdQuery : IQuery<ProductByIdDto>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
