using Quizy.Shared.DDD;
using Quizy.Tag.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizy.Tag.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<TagEntity?> FindByIdAsync(Id id);
        Task<TagEntity?> FindByUserIdAndName(Id userId, string tagName);
        Task SaveAsync(TagEntity user);

        Task SaveChangesAsync();
    }
}
