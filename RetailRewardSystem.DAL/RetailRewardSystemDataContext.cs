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
        public RetailRewardSystemDataContext(DbContextOptions options) : base(options)
        {
        }

        public RetailRewardSystemDataContext()
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RetailRewardSystem");
        }
    }
}
