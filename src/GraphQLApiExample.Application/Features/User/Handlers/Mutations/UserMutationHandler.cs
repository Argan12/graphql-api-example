using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Application.Features.User.Types.Mappings;
using UserDomain = GraphQLApiExample.Domain.Entities.User;

namespace GraphQLApiExample.Application.Features.User.Handlers.Mutations
{
    public class UserMutationHandler(IUserRepository userRepository)
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserDomain> Save(CreateUserInput input) => await _userRepository.SaveUser(input.ToDomain());
    }
}
