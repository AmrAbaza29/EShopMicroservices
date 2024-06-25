using Catalog.API.Models;
using Marten;
using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(SeedInitialProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> SeedInitialProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Iphone 14",
                    Category = {"Mobile Phones", "Apple" },
                    Description = "Dark Grey",
                    ImageFile = "iphone14grey.png",
                    Price = 30000m
                },
                new Product
                {
                    Name = "Iphone 15",
                    Category = {"Mobile Phones", "Apple" },
                    Description = "Rose Gold",
                    ImageFile = "iphone15rosegold.png",
                    Price = 44200m
                },
                new Product
                {
                    Name = "Iphone 13",
                    Category = { "Mobile Phones", "Apple" },
                    Description = "Black",
                    ImageFile = "iphone13black.png",
                    Price = 26000m
                },
                new Product
                {
                    Name = "Samsung Galaxy A54",
                    Category = {"Mobile Phones", "Samsung"},
                    Description = "Mint Green",
                    ImageFile = "samsunga54mintgreen.png",
                    Price = 14600m
                },
                new Product
                {
                    Name = "Xiaomi Note 12",
                    Category = {"Mobile Phones", "Xiaomi" },
                    Description = "Blue",
                    ImageFile = "minote12blue.png",
                    Price = 10000m
                },
                new Product
                {
                    Name = "Reno 5",
                    Category = {"Mobile Phones", "oppo" },
                    Description = "Sky Blue",
                    ImageFile = "reno5skyblue.png",
                    Price = 19000m
                },
                new Product
                {
                    Name = "LG Smart LCD",
                    Category = {"Screens", "LG", "Smart"},
                    Description = "Smart Screen",
                    ImageFile = "lgsmartscreen.png",
                    Price = 22000m
                }
            };
            return products;
        }
    }
}
