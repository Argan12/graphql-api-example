using FluentValidation.Results;

namespace GraphQLApiExample.Application.Common.Exceptions
{
    public class NotFoundException(string message) : GraphQLException(ErrorBuilder.New()
                .SetMessage(message)
                .SetCode(Constants.RESOURCE_NOT_FOUND)
                .Build())
    {
    }
}
