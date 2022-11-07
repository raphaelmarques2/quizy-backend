using Quizy.Shared.DDD;
using Quizy.User.Domain.Entities;
using Quizy.User.Domain.Exceptions;
using Quizy.User.Domain.UseCases;
using Quizy.User.Tests.Infra;

namespace Quizy.User.Tests.UseCases
{
    public class GetUserByIdTest
    {
        private readonly MemoryUserRepository repository;
        private readonly GetUserByIdUseCase getUser;

        public GetUserByIdTest()
        {
            repository = new MemoryUserRepository();
            getUser = new GetUserByIdUseCase(repository);

            repository.Users.Add(
                new UserEntity(
                    id: new Id("1"),
                    name: "A",
                    email: "a@abc.com"
                ));
            repository.Users.Add(
                new UserEntity(
                    id: new Id("2"),
                    name: "B",
                    email: "b@abc.com"
                ));
        }

        [Fact]
        public async void GetUser_ShouldReturnUser()
        {
            var user1 = await getUser.ExecuteAsync("1");
            var user2 = await getUser.ExecuteAsync("2");

            Assert.Equal("1", user1.Id);
            Assert.Equal("2", user2.Id);
        }

        [Fact]
        public async void GetUser_WithNonExistingId_ShouldThrowException()
        {
            await Assert.ThrowsAsync<UserNotFoundException>(
                async () => await getUser.ExecuteAsync("3")
            );
        }

    }
}