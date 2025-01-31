using GraphQLApiExample.Application.Common.Exceptions;
using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using UserDomain = GraphQLApiExample.Domain.Entities.User;

namespace GraphQLApiExample.Application.Features.User.Handlers.Queries
{
    public class UserQueryHandler(IUserRepository userRepository)
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserDomain> GetUsers(GetUserByMailInput input) =>
            await _userRepository.GetUserByMail(input.Mail) ?? throw new NotFoundException(Constants.ERR_USER_NOT_FOUND);
    }
}
