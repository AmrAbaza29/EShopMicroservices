using Carter;
using MediatR;

namespace Catalog.API.Products.GetProductById
{
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (ISender sender, Guid id) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                return Results.Ok(result);
            }).WithName("GetProductById")
            .Produces(200)
            .ProducesProblem(400)
            .WithSummary("Get Product By Id")
            .WithDescription("Get Product By Id");
        }
    }
}
