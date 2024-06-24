using Catalog.API.Models;

namespace Catalog.API.DTOs
{
    public record ProductByCategoryDto(IEnumerable<Product> products);
}
