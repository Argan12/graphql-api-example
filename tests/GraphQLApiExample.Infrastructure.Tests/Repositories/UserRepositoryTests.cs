using GraphQLApiExample.Infrastructure.Entities;
using GraphQLApiExample.Infrastructure.Extensions;
using GraphQLApiExample.Infrastructure.Repositories;
using Moq;
using Moq.EntityFrameworkCore;
using UserDbo = GraphQLApiExample.Infrastructure.Entities.UserDbo;
using UserDomain = GraphQLApiExample.Domain.Entities.User;

namespace GraphQLApiExample.Infrastructure.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly Mock<GraphQLApiExampleDbContext> _dbContextMock;
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        {
            _dbContextMock = new Mock<GraphQLApiExampleDbContext>();
            _userRepository = new UserRepository(_dbContextMock.Object);
        }

        [Fact]
        public async Task UserRepository_ShouldReturnsUserById()
        {
            var userId = Guid.NewGuid();

            var user = new UserDbo
            {
                Id = userId,
                Pseudo = "John Doe",
                Mail = "john.doe@gmail.com",
                RegistrationDate = DateTime.Now
            };

            _dbContextMock.Setup(db => db.User).ReturnsDbSet([ user ]);

            var res = await _userRepository.GetUserById(userId);

            Assert.NotNull(res);
            Assert.Equal(userId, res.Id);
        }

        [Fact]
        public async Task UserRepository_ShouldReturnsUserByMail()
        {
            var userId = Guid.NewGuid();
            var mailAddress = "john.doe@gmail.com";

            var user = new UserDbo
            {
                Id = userId,
                Pseudo = "John Doe",
                Mail = mailAddress,
                RegistrationDate = DateTime.Now
            };

            _dbContextMock.Setup(db => db.User).ReturnsDbSet([user]);

            var res = await _userRepository.GetUserByMail(mailAddress);

            Assert.NotNull(res);
            Assert.Equal(userId, res.Id);
            Assert.Equal(mailAddress, res.Mail);
        }

        [Fact]
        public async Task UserRepository_ShouldSaveUser()
        {
            var userDomain = new UserDomain
            {
                Pseudo = "John Doe",
                Mail = "john.doe@gmail.com",
            };

            var userDbo = userDomain.ToDbo();

            _dbContextMock.Setup(db => db.User.Add(It.IsAny<UserDbo>()))
                .Returns((UserDbo user) => _dbContextMock.Object.User.Add(user)); 

            _dbContextMock.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);  

            var result = await _userRepository.SaveUser(userDomain);

            _dbContextMock.Verify(db => db.Add(It.IsAny<UserDbo>()), Times.Once); 
            _dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once); 

            Assert.NotNull(result); 
        }

        [Fact]
        public async Task UserRepository_ShouldDeleteUser()
        {
            var userId = Guid.NewGuid();

            var user = new UserDbo
            {
                Id = userId,
                Pseudo = "John Doe",
                Mail = "john.doe@gmail.com",
                RegistrationDate = DateTime.Now
            };

            _dbContextMock.Setup(db => db.User)
                      .ReturnsDbSet([ user ]);

            _dbContextMock.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);  

            await _userRepository.DeleteUser(userId);

            _dbContextMock.Verify(db => db.Remove(It.IsAny<UserDbo>()), Times.Once); 
            _dbContextMock.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
