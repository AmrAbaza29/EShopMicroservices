using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Catalog.API.Models;
using Marten;
using MediatR;

namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductCommandHandler(IDocumentSession session) 
        : ICommandHandler<UpdateProductCommand>
    {
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(request.Id, cancellationToken)
                ?? throw new ProductNotFoundException(request.Id);

            product.Name = request.Name;
            product.Description = request.Description;
            product.ImageFile = request.ImageFile;
            product.Category = request.Category;
            product.Price = request.Price;

            await session.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
