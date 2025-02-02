using GraphQLApiExample.Application.Common.Exceptions;
using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Application.Features.User.Handlers.Mutations;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Domain.Entities;
using Moq;

namespace GraphQLApiExample.Application.Tests.Mutations.Users
{
    public class CreateUserMutationTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserMutationHandler _sut;

        public CreateUserMutationTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _sut = new UserMutationHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task UserMutation_ShouldThrowIfUserAlreadyExists()
        {
            var input = new CreateUserInput
            {
                Pseudo = "John Doe",
                Mail = "john.doe@gmail.com",
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                Pseudo = "John Doe",
                Mail = "john.doe@gmail.com"
            };

            _userRepositoryMock.Setup(x => x.GetUserByMail(It.IsAny<string>()))
                .ReturnsAsync(user);

            var ex = await Assert.ThrowsAsync<BadRequestException>(async () => await _sut.Save(input));

            Assert.Equal(Constants.ERR_MAIL_ALREADY_EXISTS, ex.Message);
        }

        [Fact]
        public async Task UserMutation_Ok()
        {
            var expectedGuid = Guid.NewGuid();

            var input = new CreateUserInput
            {
                Pseudo = "John Doe",
                Mail = "john.doe@gmail.com"
            };

            User? user = null;
            var savedUser = new User
            {
                Id = expectedGuid,
                Pseudo = "John Doe",
                Mail = "john.doe@gmail.com",
                RegistrationDate = DateTime.Now
            };

            _userRepositoryMock.Setup(x => x.GetUserByMail(It.IsAny<string>())).ReturnsAsync(user);
            _userRepositoryMock.Setup(x => x.SaveUser(It.IsAny<User>())).ReturnsAsync(savedUser);

            var res = await _sut.Save(input);

            Assert.Equal(expectedGuid, res.Id);
        }
    }
}
