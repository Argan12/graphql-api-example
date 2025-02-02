using GraphQLApiExample.Application.Common.Exceptions;
using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Application.Features.User.Types.Mappings;
using UserDomain = GraphQLApiExample.Domain.Entities.User;

namespace GraphQLApiExample.Application.Features.User.Handlers.Mutations
{
    public class UserMutationHandler(IUserRepository userRepository)
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserDomain> Save(CreateUserInput input)
        {
            var user = await _userRepository.GetUserByMail(input.Mail);

            if (user is not null)
            {
                throw new BadRequestException(Constants.ERR_MAIL_ALREADY_EXISTS);
            }

            return await _userRepository.SaveUser(input.ToDomain());
        }

        public async Task Remove(DeleteUserInput input)
        {
            _ = await _userRepository.GetUserById(input.Id) ?? throw new NotFoundException(Constants.ERR_USER_NOT_FOUND);
            await _userRepository.DeleteUser(input.Id);
        }
    }
}
