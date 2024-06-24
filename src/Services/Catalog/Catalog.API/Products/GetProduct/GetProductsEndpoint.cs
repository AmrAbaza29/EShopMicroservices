using Carter;
using MediatR;

namespace Catalog.API.Products.GetProduct
{
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                return Results.Ok(result);
            }).WithName("GetProducts")
            .Produces(200)
            .ProducesProblem(400)
            .WithSummary("Get Product")
            .WithDescription("Get Product"); ;
        }
    }
}
