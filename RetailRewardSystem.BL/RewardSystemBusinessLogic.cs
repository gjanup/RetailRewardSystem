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

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            using (var _dbContext = new RetailRewardSystemDataContext())
            {
                transactions = _dbContext.Transactions.Where(t => t.RewardPoints == null).ToList();
            }

            return transactions;
        }
        public void SaveTransactions(Customer customer)
        {
            using (var _dbContext = new RetailRewardSystemDataContext()) 
            {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
            }

        }

        public void SaveTransactionsBulk(List<Transaction> transactions)
        {
            using (var _dbContext = new RetailRewardSystemDataContext())
            {
                foreach (var transaction in transactions)
                {
                    var t = _dbContext.Transactions.Where(t => t.Id == transaction.Id).FirstOrDefault();
                    if (t != null)
                    {
                        t.RewardPoints = transaction.RewardPoints;
                        t.PurchaseAmount = transaction.PurchaseAmount;
                        t.Date = transaction.Date;
                    }
                    else
                    {
                        _dbContext.Transactions.Add(transaction);
                    }
                }
                _dbContext.SaveChanges();
            }
        }

        public void SaveCustomerAndTransactionsBulk(List<Customer> customers)
        {
            using (var _dbContext = new RetailRewardSystemDataContext())
            {
                foreach (var customer in customers)
                {
                    if (customer.Id > 0)
                    {
                        var customerTransactions = _dbContext.Transactions.Where(t=>t.CustomerId == customer.Id).ToList();
                        if (customer.Transactions.Count > 0)
                        {
                            foreach (var transaction in customer.Transactions)
                            {
                                //var dbTransaction = _dbContext.Transactions.Where(c => c.Id == transaction.Id).FirstOrDefault();
                                if (transaction.Id > 0)
                                {
                                    var t = customerTransactions.Where(t => t.Id == transaction.Id).FirstOrDefault();
                                    if (t != null)
                                    {
                                        t.RewardPoints = transaction.RewardPoints;
                                        t.PurchaseAmount = transaction.PurchaseAmount;
                                        t.Date = transaction.Date;
                                    }
                                }
                                else
                                {
                                    _dbContext.Transactions.Add(transaction);
                                }
                            }
                        }

                    }
                    else
                    {
                        _dbContext.Customers.Add(customer);
                    }

                }
                _dbContext.SaveChanges();
            }

        }
    }
}
