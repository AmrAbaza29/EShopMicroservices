namespace Catalog.API.DTOs
{
    public record GetAllProductsRequest(int PageNumber = 1, int PageSize = 3);
}
