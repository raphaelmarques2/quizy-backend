using Quizy.Shared.DDD;
using Quizy.User.Domain.Entities;

namespace Quizy.User.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity?> FindByEmailAsync(string email);
        Task<UserEntity?> FindByIdAsync(Id id);

        Task SaveAsync(UserEntity user);

        Task SaveChangesAsync();
    }

}
