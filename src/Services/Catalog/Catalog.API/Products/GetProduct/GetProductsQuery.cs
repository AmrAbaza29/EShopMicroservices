using BuildingBlocks.CQRS;
using Catalog.API.DTOs;

namespace Catalog.API.Products.GetProduct
{
    public class GetProductsQuery : IQuery<ProductResultDto>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetProductsQuery()
        {
            
        }

        public GetProductsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
