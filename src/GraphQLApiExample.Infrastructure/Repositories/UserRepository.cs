using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Infrastructure.Entities;
using GraphQLApiExample.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using UserDomain = GraphQLApiExample.Domain.Entities.User;

namespace GraphQLApiExample.Infrastructure.Repositories
{
    public class UserRepository(GraphQLApiExampleDbContext context) : IUserRepository
    {
        private readonly GraphQLApiExampleDbContext _context = context;

        /// <summary>
        /// Save user
        /// </summary>
        /// <param name="user">User domain</param>
        /// <param name="cancellationToken"></param>
        /// <returns>User domain</returns>
        public async Task<UserDomain> SaveUser(UserDomain user)
        {
            var userDbo = user.ToDbo();

            _context.Add(userDbo);
            await _context.SaveChangesAsync();

            return userDbo.ToDomain();
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User domain</returns>
        public async Task<UserDomain?> GetUserById(Guid id)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Id == id);
            return user?.ToDomain();
        }

        /// <summary>
        /// Get user by mail address
        /// </summary>
        /// <param name="mail"></param>
        /// <returns>User</returns>
        public async Task<UserDomain?> GetUserByMail(string mail)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.Mail == mail);
            return user?.ToDomain();
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteUser(Guid id)
        {
            var user = await _context.User.SingleAsync(x => x.Id == id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
