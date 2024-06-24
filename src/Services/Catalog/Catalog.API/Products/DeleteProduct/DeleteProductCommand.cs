using BuildingBlocks.CQRS;

namespace Catalog.API.Products.DeleteProduct
{
    public class DeleteProductCommand : ICommand
    {
        public Guid Id { get; set; }

        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}
