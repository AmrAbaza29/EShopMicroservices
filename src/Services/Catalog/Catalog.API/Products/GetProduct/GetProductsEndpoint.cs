using Carter;
using Catalog.API.DTOs;
using Mapster;
using MediatR;

namespace Catalog.API.Products.GetProduct
{
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetAllProductsRequest request,ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();
                var result = await sender.Send(query);
                return Results.Ok(result);
            }).WithName("GetProducts")
            .Produces(200)
            .ProducesProblem(400)
            .WithSummary("Get Product")
            .WithDescription("Get Product"); ;
        }
    }
}
