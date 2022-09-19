using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using notionclone.entity;

namespace notionclone.data.Concrete.EfCore
{
    public class NotionContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Template> Templates { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-87LVU45;Database=NotionDB;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTemplate>().HasKey(pt => new { pt.TemplateId, pt.ProductId });
        }
    }
}