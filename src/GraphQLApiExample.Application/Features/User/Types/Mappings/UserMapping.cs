using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Application.Features.User.Types.Outputs;
using UserDomain = GraphQLApiExample.Domain.Entities.User;

namespace GraphQLApiExample.Application.Features.User.Types.Mappings
{
    public static class UserMapping
    {
        public static UserDomain ToDomain(this CreateUserInput input)
        {
            return new UserDomain
            {
                Pseudo = input.Pseudo,
                Mail = input.Mail
            };
        }

        public static UserDto ToOutput(this UserDomain user)
        {
            return new UserDto
            {
                Id = user.Id,
                Pseudo = user.Pseudo,
                Mail = user.Mail,
                RegistrationDate = user.RegistrationDate,
            };
        }
    }
}
