using FluentValidation;

namespace Catalog.API.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p=>p.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(p => p.Category).NotEmpty().WithMessage("Category is required");
            RuleFor(p => p.ImageFile).NotEmpty().WithMessage("ImageFile is required");
            RuleFor(p => p.Description).NotEmpty().WithMessage("Description is required"); 
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
