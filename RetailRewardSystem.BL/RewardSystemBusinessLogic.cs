using RetailRewardSystem.Common;
using RetailRewardSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailRewardSystem.BAL
{
    public class RewardSystemBusinessLogic
    {
        RetailRewardSystemDataContext _dbContext = new RetailRewardSystemDataContext();

        public void GetTransactions(CustomerTransactions customerTransactions)
        {

        }
        public void SaveTransactions(CustomerTransactions customerTransactions)
        {
            using (var _dbContext = new RetailRewardSystemDataContext()) 
            {
                _dbContext.Customers.Add(customerTransactions.Customer);
                _dbContext.SaveChanges();

                //customerTransactions.Transactions.Select(t=>t.CustomerId<0).
                //foreach (var transaction in customerTransactions.Transactions)
                //{
                //    _dbContext.Transactions.Add(transaction);
                //}

                //_dbContext.SaveChanges();
            }

        }
    }
}
