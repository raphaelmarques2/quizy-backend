using Quizy.Shared.DDD;
using Quizy.Tag.Domain.UseCases;
using Quizy.Tag.Tests.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizy.Tag.Tests.UseCases
{
    public class FollowTagTest
    {
        private readonly MemoryTagRepository repository;
        private readonly FollowTagUseCase followTag;

        public FollowTagTest()
        {
            repository = new MemoryTagRepository();
            followTag = new FollowTagUseCase(repository);
        }

        [Fact]
        public async void FollowTag_ShouldCreateTag()
        {
            var tagDto = await followTag.ExecuteAsync(new Id("1"), "X");

            Assert.NotEmpty(tagDto.Id);
            Assert.Equal("1", tagDto.UserId);
            Assert.Equal("X", tagDto.Name);

            Assert.Single(repository.Tags);

            Assert.True(repository.SaveChangesWasCalled);
        }
    }
}
