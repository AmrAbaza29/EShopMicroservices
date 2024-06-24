using Carter;
using MediatR;

namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{id}", async (ISender sender, Guid id) =>
            {
                await sender.Send(new DeleteProductCommand(id));
                return Results.NoContent();
            }).WithName("DeleteProduct")
            .Produces(200)
            .ProducesProblem(400)
            .WithSummary("Delete Product")
            .WithDescription("Delete Product"); ;
        }
    }
}
