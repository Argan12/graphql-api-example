using FluentValidation;
using HotChocolate.Resolvers;

namespace GraphQLApiExample.WebApp.Middlewares
{
    public class ValidationMiddleware(FieldDelegate next)
    {
        private readonly FieldDelegate _next = next;

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            var arguments = context.Selection.SyntaxNode.Arguments;

            foreach (var argument in arguments)
            {
                var argumentValue = context.ArgumentValue<object>(argument.Name.Value);
                if (argumentValue == null) continue;

                var validatorType = typeof(IValidator<>).MakeGenericType(argumentValue.GetType());

                if (context.Services.GetService(validatorType) is IValidator validator)
                {
                    var validationContext = new ValidationContext<object>(argumentValue);
                    var validationResult = await validator.ValidateAsync(validationContext);

                    if (!validationResult.IsValid)
                    {
                        var errors = validationResult.Errors
                            .Select(error => ErrorBuilder.New()
                                .SetMessage(error.ErrorMessage)
                                .SetCode("VALIDATION_ERROR")
                                .Build())
                            .ToList();

                        throw new GraphQLException(errors);
                    }
                }
            }

            await _next(context);
        }
    }
}