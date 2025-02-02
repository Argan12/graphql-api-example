using GraphQLApiExample.Application.Common.Exceptions;
using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Application.Features.User.Handlers.Mutations;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Domain.Entities;
using Moq;

namespace GraphQLApiExample.Application.Tests.Mutations.Users
{
    public class DeleteUserMutationTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserMutationHandler _sut;

        public DeleteUserMutationTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _sut = new UserMutationHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task UserMutationHandler_ShouldThrowIfUserDoesNotExist()
        {
            var input = new DeleteUserInput
            {
                Id = Guid.NewGuid()
            };

            User? user = null;

            _userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<Guid>())).ReturnsAsync(user);
            
            var ex = await Assert.ThrowsAsync<NotFoundException>(async () => await _sut.Remove(input));

            Assert.Equal(Constants.ERR_USER_NOT_FOUND, ex.Message);
        }

        [Fact]
        public async Task UserMutationHandler_Ok()
        {
            var userId = Guid.NewGuid();

            var input = new DeleteUserInput
            {
                Id = userId
            };

            var user = new User
            {
                Id = userId,
                Pseudo = "John Doe",
                Mail = "john.doe@gmail.com",
                RegistrationDate = DateTime.Now
            };

            _userRepositoryMock.Setup(x => x.GetUserById(It.IsAny<Guid>())).ReturnsAsync(user);
            
            await _sut.Remove(input);
            _userRepositoryMock.Verify(x => x.DeleteUser(It.IsAny<Guid>()));
        }
    }
}
