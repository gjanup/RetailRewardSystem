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

        public List<CustomerTransactions> GetTransactions()
        {
            List<CustomerTransactions> customerTransactions = new List<CustomerTransactions>();
            List<Customer> customers = new List<Customer>();
            using (var _dbContext = new RetailRewardSystemDataContext())
            {
                customers = _dbContext.Customers.ToList();
            }

            foreach (var customer in customers)
            {
                customerTransactions.Add(new CustomerTransactions() { Customer = customer});
            }

            return customerTransactions;
        }
        public void SaveTransactions(CustomerTransactions customerTransactions)
        {
            using (var _dbContext = new RetailRewardSystemDataContext()) 
            {
                _dbContext.Customers.Add(customerTransactions.Customer);
                _dbContext.SaveChanges();
            }

        }

        public void SaveTransactionsBulk(List<CustomerTransactions> customerTransactions)
        {
            using (var _dbContext = new RetailRewardSystemDataContext())
            {
                foreach (var custTrans in customerTransactions)
                {
                    _dbContext.Customers.Add(custTrans.Customer);

                    foreach (var transaction in custTrans.Customer.Transactions)
                    { 
                        _dbContext.Transactions.Add(transaction);
                    }
                }
                _dbContext.SaveChanges();
                //_dbContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Customers ON;");
            }

        }
    }
}
