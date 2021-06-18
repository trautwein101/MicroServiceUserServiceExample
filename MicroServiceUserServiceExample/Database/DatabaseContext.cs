using MicroServiceUserServiceExample.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceUserServiceExample.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } //for working with entities

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=UserMicroservice;Trusted_Connection=True;MultipleActiveResultSets=True");
        }


    }
}
