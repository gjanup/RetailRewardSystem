using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailRewardSystem.Common
{
    public class Customer
    {
        //[Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Transaction> Transactions { get; set; }

        public Customer()
        {
            Transactions = new List<Transaction>();
        }
    }
}
