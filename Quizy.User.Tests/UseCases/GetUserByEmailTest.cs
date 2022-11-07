using Quizy.Shared.DDD;
using Quizy.User.Domain.Entities;
using Quizy.User.Domain.Exceptions;
using Quizy.User.Domain.UseCases;
using Quizy.User.Tests.Infra;
using Xunit;

namespace Quizy.User.Tests.UseCases
{
    public class GetUserByEmailTest
    {
        private readonly MemoryUserRepository repository;
        private readonly GetUserByEmailUseCase getUser;

        public GetUserByEmailTest()
        {
            repository = new MemoryUserRepository();
            getUser = new GetUserByEmailUseCase(repository);

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
            var user1 = await getUser.ExecuteAsync("a@abc.com");
            var user2 = await getUser.ExecuteAsync("b@abc.com");

            Assert.Equal("1", user1.Id);
            Assert.Equal("2", user2.Id);
        }

        [Fact]
        public async void GetUser_WithNonExistingId_ShouldThrowException()
        {
            await Assert.ThrowsAsync<UserNotFoundException>(
                async () => await getUser.ExecuteAsync("c@abc.com")
            );
        }

    }
}