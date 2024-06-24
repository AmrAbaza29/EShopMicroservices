using Carter;
using Mapster;
using MediatR;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products/", async (ISender sender, UpdateProductRequest request) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                await sender.Send(command);
                return Results.NoContent();
            });
        }
    }
}
