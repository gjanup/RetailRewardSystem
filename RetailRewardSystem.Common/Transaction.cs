using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailRewardSystem.Common
{
    public class Transaction
    {
        //[Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public long? PurchaseAmount { get; set; }
        public long? RewardPoints { get; set; }

    }
}
