using Microsoft.EntityFrameworkCore;
using Quizy.Shared.DDD;
using Quizy.User.Domain.Entities;
using Quizy.User.Domain.Interfaces;

namespace Quizy.User.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<UserEntity?> FindByEmailAsync(string email)
        {
            var user = await _context.Users.Where(item => item.Email == email).FirstOrDefaultAsync();
            if (user == null) return null;

            return user.toUserEntity();
        }

        public async Task<UserEntity?> FindByIdAsync(Id id)
        {
            var user = await _context.Users.Where(item => item.Id == id.Value).FirstOrDefaultAsync();
            
            if (user == null) return null;

            return user.toUserEntity();
        }

        public async Task SaveAsync(UserEntity user)
        {
            var userModel = user.toUserModel();
            await _context.Users.AddAsync(userModel);
        }

        public async Task SaveChangesAsync() {
            await _context.SaveChangesAsync();
        }
    }
}
