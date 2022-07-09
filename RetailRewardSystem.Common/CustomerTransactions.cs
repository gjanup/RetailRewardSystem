using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailRewardSystem.Common
{
    public class CustomerTransactions
    {
        public  Customer Customer { get; set; }
        public List<Transaction> Transactions { get; set; }

        public CustomerTransactions()
        { 
            Transactions = new List<Transaction>();
        }

    }
}
