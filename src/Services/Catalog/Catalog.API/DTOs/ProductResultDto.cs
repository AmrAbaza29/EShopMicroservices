using Catalog.API.Models;

namespace Catalog.API.DTOs
{
    public record ProductResultDto(IEnumerable<Product> Products);

}
