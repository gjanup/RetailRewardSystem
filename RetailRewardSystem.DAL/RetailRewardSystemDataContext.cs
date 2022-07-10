using Microsoft.EntityFrameworkCore;
using RetailRewardSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailRewardSystem.DAL
{
    public class RetailRewardSystemDataContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }


        //public virtual DbSet<Transaction> Transactions { get; set; }
        public RetailRewardSystemDataContext(DbContextOptions options) : base(options)
        {
        }

        public RetailRewardSystemDataContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RetailRewardSystem");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(
                c => {
                    c.HasKey(c => c.Id);
                    c.Property(c => c.Id).UseIdentityColumn<int>(1, 1);
                    c.HasMany(c => c.Transactions);
                    c.ToTable("Customers");
                }
                );

            modelBuilder.Entity<Transaction>(c =>
            {
                c.HasKey(c=>c.Id);
                c.Property(c => c.Id).UseIdentityColumn<int>(1,1);
                c.ToTable("Transactions");
            });
        }


    }
}
