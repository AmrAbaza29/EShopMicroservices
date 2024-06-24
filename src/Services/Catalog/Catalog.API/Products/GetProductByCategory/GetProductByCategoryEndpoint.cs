using Carter;
using MediatR;

namespace Catalog.API.Products.GetProductByCategory
{
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (ISender sender, string category) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));
                return Results.Ok(result);
            }).WithName("GetProductByCategory")
            .Produces(200)
            .ProducesProblem(400)
            .WithSummary("Get Products By Category")
            .WithDescription("Get Products By Category");
        }
    }
}
