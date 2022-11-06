using NuGet.Frameworks;
using Quizy.Shared.DDD;
using Quizy.User.Domain.Dtos;
using Quizy.User.Domain.Entities;
using Quizy.User.Domain.Exceptions;
using Quizy.User.Domain.UseCases;
using Quizy.User.Tests.Infra;
using Xunit;
using Xunit.Abstractions;

namespace Quizy.User.Tests.UseCases
{
    public class CreateUserTest
    {
        private readonly MemoryUserRepository repository;
        private readonly CreateUserUseCase createUser;

        public CreateUserTest()
        {
            repository = new MemoryUserRepository();
            createUser = new CreateUserUseCase(repository);
        }

        [Fact]
        public async void CreateUser_ShouldReturnUser_AndSaveIt()
        {
            var userDto = await createUser.ExecuteAsync("John", "john@abc.com");

            Assert.NotEmpty(userDto.Id);
            Assert.Equal("John", userDto.Name);
            Assert.Equal("john@abc.com", userDto.Email);

            Assert.Single(repository.users);

            Assert.True(repository.SaveChangesCalled);
        }

        [Fact]
        public async void CreateUser_WithExistingEmail_ShuouldThrowsException_AndNotSaveIt()
        {
            repository.users.Add(
                new UserEntity(
                    id: new Id(),
                    name: "John",
                    email: "john@abc.com"
                ));

            await Assert.ThrowsAsync<EmailAlreadyExistsException>(async () => await createUser.ExecuteAsync("John", "john@abc.com"));

            Assert.Single(repository.users);
        }

    }
}