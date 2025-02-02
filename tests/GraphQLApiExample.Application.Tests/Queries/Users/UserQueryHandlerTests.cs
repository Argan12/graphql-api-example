using GraphQLApiExample.Application.Common.Exceptions;
using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Application.Features.User.Handlers.Queries;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Domain.Entities;
using Moq;

namespace GraphQLApiExample.Application.Tests.Queries.Users
{
    public class UserQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserQueryHandler _sut;

        public UserQueryHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _sut = new UserQueryHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task UserQuery_ShouldThrowIfUserDoesNotExist()
        {
            var input = new GetUserByMailInput
            {
                Mail = "john.doe@gmail.com"
            };

            User? user = null;

            _userRepositoryMock.Setup(x => x.GetUserByMail(It.IsAny<string>())).ReturnsAsync(user);

            var ex = await Assert.ThrowsAsync<NotFoundException>(async () => await _sut.GetByMail(input));

            Assert.Equal(Constants.ERR_USER_NOT_FOUND, ex.Message);
        }

        [Fact]
        public async Task UserQuery_Ok()
        {
            var userId = Guid.NewGuid();
            var userPseudo = "John Doe";
            var mailAddress = "john.doe@gmail.com";

            var input = new GetUserByMailInput
            {
                Mail = "john.doe@gmail.com"
            };

            var user = new User
            {
                Id = userId,
                Pseudo = userPseudo,
                Mail = mailAddress,
                RegistrationDate = DateTime.Now
            };

            _userRepositoryMock.Setup(x => x.GetUserByMail(It.IsAny<string>())).ReturnsAsync(user);

            var res = await _sut.GetByMail(input);

            Assert.Equal(userId, res.Id);
            Assert.Equal(userPseudo, res.Pseudo); 
            Assert.Equal(mailAddress, res.Mail);
        }
    }
}
