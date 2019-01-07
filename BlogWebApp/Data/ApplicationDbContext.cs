using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogWebApp.Models;

namespace BlogWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BlogWebApp.Models.Post> Post { get; set; }
        public DbSet<BlogWebApp.Models.Comment> Comment { get; set; }
        //public DbSet<BlogWebApp.Models.Person> People { get; set; }
    }
}
