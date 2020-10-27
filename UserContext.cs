using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Intro
{
    public class UserContext : DbContext
    {
        public DbSet<Users> User { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=User;Integrated Security=True");
            
        }
    }
    
    public class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string salt { get; set; }
        public string Hashed { get; set; }

    }
}