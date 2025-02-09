namespace GraphQLApiExample.Application.Common.Exceptions
{
    public class UnauthorizedException(string message) : GraphQLException(ErrorBuilder.New()
                .SetMessage(message)
                .SetCode(Constants.UNAUTHORIZED)
                .Build())
    {
    }
}
