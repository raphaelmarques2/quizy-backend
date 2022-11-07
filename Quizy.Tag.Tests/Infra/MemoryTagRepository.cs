using Quizy.Shared.DDD;
using Quizy.Tag.Domain.Entities;
using Quizy.Tag.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizy.Tag.Tests.Infra
{
    internal class MemoryTagRepository : ITagRepository
    {

        public List<TagEntity> Tags { get; set; }
        public bool SaveChangesWasCalled { get; set; } = false;


        public MemoryTagRepository()
        {
            Tags = new List<TagEntity>();
        }

        public async Task<TagEntity?> FindByIdAsync(Id id)
        {
            return Tags.Where(item => item.Id.Equals(id)).FirstOrDefault();
        }

        public async Task<TagEntity?> FindByUserIdAndName(Id userId, string tagName)
        {
            return Tags.Where(item => item.UserId.Equals(userId) && item.Name == tagName).FirstOrDefault();
        }

        public async Task SaveAsync(TagEntity tag)
        {
            Tags.Add(tag);
        }

        public async Task SaveChangesAsync()
        {
            SaveChangesWasCalled = true;
        }
    }
}
