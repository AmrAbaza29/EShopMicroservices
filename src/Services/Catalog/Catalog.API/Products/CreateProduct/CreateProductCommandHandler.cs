using BuildingBlocks.CQRS;
using Catalog.API.Models;
using FluentValidation;
using Marten;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IDocumentSession session;
        //private readonly IValidator<CreateProductCommand> validator;

        public CreateProductCommandHandler(IDocumentSession session/*, IValidator<CreateProductCommand> validator*/)
        {
            this.session = session;
            //this.validator = validator;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //var result = await validator.ValidateAsync(request, cancellationToken);
            //if(result.Errors.Any())
            //{
            //    throw new ValidationException(result.Errors);
            //}

            var product = new Product
            {
                Name = request.Name,
                Category = request.Category,
                Description = request.Description,
                ImageFile = request.ImageFile,
                Price = request.Price
            };

            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //save to db 

            return Unit.Value;
        }
    }
}
