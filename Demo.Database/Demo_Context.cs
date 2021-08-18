using Demo.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Database
{
    public class Demo_Context : DbContext
    {
        public Demo_Context(DbContextOptions<Demo_Context> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Student> Students {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = new Guid("23c2ccb8-bc71-4f20-94da-02bbc1cc7066"),
                    Email = "deepak@gmail.com",
                    FirstName = "Deepak",
                    LastName = "Kumar",
                    Password= "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918"
                }
            );
        }
    }
}
