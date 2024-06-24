using BuildingBlocks.CQRS;
using Catalog.API.Exceptions;
using Catalog.API.Models;
using Marten;
using MediatR;

namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand>
    {
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await session.
                LoadAsync<Product>(request.Id, cancellationToken)
                ?? throw new ProductNotFoundException(request.Id);
                

            session.Delete(product);
            await session.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
