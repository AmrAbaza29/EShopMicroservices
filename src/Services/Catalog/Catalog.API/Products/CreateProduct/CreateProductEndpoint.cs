using Carter;
using Mapster;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string>Category, string Description, string ImageFile, decimal Price);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async(CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                await sender.Send(command);
                return Results.Created();
            }).WithName("CreateProduct")
            .Produces(201)
            .ProducesProblem(400)
            .WithSummary("Create Product")
            .WithDescription("Create Product");

        }
    }
}
