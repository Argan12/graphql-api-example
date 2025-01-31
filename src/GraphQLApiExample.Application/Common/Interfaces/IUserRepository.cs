using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQLApiExample.Domain.Entities;

namespace GraphQLApiExample.Application.Common.Interfaces
{
    public interface IUserRepository
    {
        Task<User> SaveUser(User user);

        Task<User?> GetUserByMail(string mail);
    }
}
