using System.Reflection.Metadata;
using GraphQLApiExample.Application;
using GraphQLApiExample.Application.Common.Exceptions;
using GraphQLApiExample.Application.Features.User.Handlers.Queries;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Application.Features.User.Types.Mappings;
using GraphQLApiExample.Application.Features.User.Types.Outputs;
using GraphQLApiExample.Domain.Entities;

namespace GraphQLApiExample.WebApp.GraphQL
{
    public class Query
    {
        public async Task<UserDto> GetUserByMail([Service] UserQueryHandler handler, GetUserByMailInput input)
        {
           var user = await handler.GetByMail(input);
            return user.ToOutput();
        }
    }
}
