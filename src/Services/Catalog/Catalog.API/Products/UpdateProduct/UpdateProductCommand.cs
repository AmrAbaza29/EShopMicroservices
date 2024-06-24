using BuildingBlocks.CQRS;

namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default!;
        public string ImageFile { get; set; } = default!;
        public decimal Price { get; set; }

        public UpdateProductCommand()
        {
            
        }

        public UpdateProductCommand(string name, List<string> category, string description, string imageFile, decimal price, Guid id)
        {
            Name = name;
            Category = category;
            Description = description;
            ImageFile = imageFile;
            Price = price;
            Id = id;
        }
    }
}
