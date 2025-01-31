using GraphQLApiExample.Application.Features.User;
using GraphQLApiExample.Application.Features.User.Handlers.Mutations;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Application.Features.User.Types.Mappings;
using GraphQLApiExample.Application.Features.User.Types.Outputs;

namespace GraphQLApiExample.WebApp.GraphQL
{
    public class Mutation
    {
        public async Task<UserDto> CreateUser([Service] UserMutationHandler handler, CreateUserInput input)
        {
            var user = await handler.Save(input);
            return user.ToOutput();
        }
    }
}
