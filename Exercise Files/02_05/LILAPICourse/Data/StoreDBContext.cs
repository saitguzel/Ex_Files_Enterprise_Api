﻿using LILAPICourse.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LILAPICourse.Data
{
    public class StoreDBContext:DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options)
  : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<PriceHistory> PriceHistory { get; set; }
        public DbSet<RankHistory> RankHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(z => {
                z.HasKey(z => z.Id);
                z.HasOne(p => p.ProductCategory).WithMany(pc => pc.Products).HasForeignKey(p => p.ProductCategoryId);
            });
            modelBuilder.Entity<ProductCategory>(z => {
                z.HasKey(z => z.Id);
            });
            modelBuilder.Entity<PriceHistory>(z => {
                z.HasKey(z => z.Id);
                z.HasOne(p => p.Product).WithMany(pc => pc.PriceHistories).HasForeignKey(p => p.ProductId);

            });
            modelBuilder.Entity<RankHistory>(z => {
                z.HasKey(z => z.Id);
                z.HasOne(p => p.Product).WithMany(pc => pc.RankHistories).HasForeignKey(p => p.ProductId);

            });



            modelBuilder.Seed();

        }




    }
}
