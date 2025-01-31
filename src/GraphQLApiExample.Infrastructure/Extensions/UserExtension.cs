using UserDbo = GraphQLApiExample.Infrastructure.Entities.User;
using UserDomain = GraphQLApiExample.Domain.Entities.User;

namespace GraphQLApiExample.Infrastructure.Extensions
{
    public static class UserExtension
    {
        public static UserDomain ToDomain(this UserDbo user)
        {
            return new UserDomain
            {
                Id = user.Id,
                Pseudo = user.Pseudo,
                Mail = user.Mail,
                RegistrationDate = user.RegistrationDate
            };
        }

        public static UserDbo ToDbo(this UserDomain user)
        {
            return new UserDbo
            {
                Id = Guid.NewGuid(),
                Pseudo = user.Pseudo,
                Mail = user.Mail,
                RegistrationDate = DateTime.Now
            };
        }
    }
}
