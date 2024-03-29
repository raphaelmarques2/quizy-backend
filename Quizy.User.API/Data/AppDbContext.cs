﻿using Microsoft.EntityFrameworkCore;

namespace Quizy.User.API.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
