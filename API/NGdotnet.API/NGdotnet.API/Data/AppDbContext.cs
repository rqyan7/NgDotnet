using System;
using Microsoft.EntityFrameworkCore;
using NGdotnet.API.Models.Domain;

namespace NGdotnet.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {  
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}

