using Quizy.Shared.DDD;
using Quizy.User.Domain.Entities;
using Quizy.User.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizy.User.Tests.Infra
{
    internal class MemoryUserRepository : IUserRepository
    {
        public List<UserEntity> users { get; set; }
        public bool SaveChangesCalled { get; set; } = false;


        public MemoryUserRepository()
        {
            users = new List<UserEntity>();
        }

        public async Task<UserEntity?> FindByEmailAsync(string email)
        {
            var user = users.Find((item) => item.Email.Equals(email));
            return user;
        }

        public async Task<UserEntity?> FindByIdAsync(Id id)
        {
            var user = users.Find((item) => item.Id.Equals(id));
            return user;
        }

        public async Task SaveAsync(UserEntity user)
        {
            users.Add(user);
        }

        public async Task SaveChangesAsync() {
            SaveChangesCalled = true;
        }
    }
}
