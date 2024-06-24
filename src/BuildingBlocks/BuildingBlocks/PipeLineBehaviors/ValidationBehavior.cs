using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.PipeLineBehaviors
{
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResult = await Task.WhenAll
                (validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var validationErrors = validationResult
                .Where(v=>v.Errors.Any())
                .SelectMany(v=>v.Errors)
                .ToList();

            if(validationErrors.Any())
                throw new ValidationException(validationErrors);

            return await next();
        }
    }
}
