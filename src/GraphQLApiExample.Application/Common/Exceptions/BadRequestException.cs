namespace GraphQLApiExample.Application.Common.Exceptions
{
    public class BadRequestException(string message) : GraphQLException(ErrorBuilder.New()
                .SetMessage(message)
                .SetCode(Constants.BAD_REQUEST)
                .Build())
    {
    }
}
