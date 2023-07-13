﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repositories.Concrete.EntityFramework
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}