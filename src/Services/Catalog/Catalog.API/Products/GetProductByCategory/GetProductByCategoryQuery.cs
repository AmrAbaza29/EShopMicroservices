using BuildingBlocks.CQRS;
using Catalog.API.DTOs;

namespace Catalog.API.Products.GetProductByCategory
{
    public class GetProductByCategoryQuery : IQuery<ProductByCategoryDto>
    {
        public string Category {  get; set; }

        public GetProductByCategoryQuery()
        {
            
        }
        public GetProductByCategoryQuery(string category)
        {
            Category = category;
        }
    }
}
