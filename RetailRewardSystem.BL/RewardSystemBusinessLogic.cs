using RetailRewardSystem.Common;
using RetailRewardSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailRewardSystem.BAL
{
    public class RewardSystemBusinessLogic : IRewardSystemBusinessLogic
    {
        IRewardSystemDataAccess rewardSystemDataAccess = new RewardSystemDataAccess();

       public void CalculateReward()
        {
            for (; ; )
            {
                var transactions = rewardSystemDataAccess.GetTransactions();

                if (transactions != null && transactions.Count > 0)
                {
                    foreach (var transaction in transactions)
                    {
                        if (transaction.RewardPoints == null)
                        {
                            if (transaction.PurchaseAmount > 50 && transaction.PurchaseAmount <= 100)
                            {
                                transaction.RewardPoints = transaction.PurchaseAmount - 50;
                            }
                            else if (transaction.PurchaseAmount >= 100)
                            {
                                transaction.RewardPoints = (transaction.PurchaseAmount - 50) + (transaction.PurchaseAmount - 100);
                            }
                        }
                    }
                    rewardSystemDataAccess.SaveTransactionsBulk(transactions);
                }
                else
                {
                    Thread.Sleep(60000);
                }
            }
        }

        public void CalculateReward(IEnumerable<Transaction> transactions)
        {

            if (transactions != null && transactions.Count() > 0)
            {
                foreach (var transaction in transactions)
                {

                        if (transaction.PurchaseAmount > 50 && transaction.PurchaseAmount <= 100)
                        {
                            transaction.RewardPoints = transaction.PurchaseAmount - 50;
                        }
                        else if (transaction.PurchaseAmount >= 100)
                        {
                            transaction.RewardPoints = (transaction.PurchaseAmount - 50) + (transaction.PurchaseAmount - 100);
                        }
                    
                }
            }
        }

        public IEnumerable<Customer> CalculateReward(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                CalculateReward(customer.Transactions);
                var groupTransaction = customer.Transactions.GroupBy(t => t.Date.Month).Select(t => new Transaction()
                {
                    Date = t.FirstOrDefault().Date,
                    RewardPoints = t.Sum(c => c.RewardPoints),
                    PurchaseAmount = t.Sum(c => c.PurchaseAmount)
                });
                if (groupTransaction != null)
                    customer.Transactions = groupTransaction.ToList();
            }
            return customers;
        }

        public Customer GetRewards(Customer customer)
        {
            List<Transaction> transactions = rewardSystemDataAccess.GetTransactions(customer);

            var groupTransaction = transactions.GroupBy(t => t.Date.Month).Select(t => new Transaction() { 
                                                                                        Date = t.FirstOrDefault().Date,
                                                                                        RewardPoints = t.Sum(c=>c.RewardPoints),
                                                                                        PurchaseAmount = t.Sum(c=>c.PurchaseAmount)
                                                                                        });
            if (groupTransaction != null)
                customer.Transactions = groupTransaction.ToList();

            return customer;
        }

        public void SaveTransactions(IEnumerable<Customer> customers)
        {
            List<Transaction> transactions = new List<Transaction>();
            List<Customer> new_customers = new List<Customer>();
            if (customers.Count() > 0)
            {
                foreach (var customer in customers)
                {
                    if (rewardSystemDataAccess.IsCustomerPresent(customer))
                    {                   
                        customer.Transactions.ForEach(t=> transactions.Add(t));
                        //rewardSystemDataAccess.SaveTransactionsBulk(customer.Transactions);
                    }
                    else {
                        new_customers.Add(customer);
                    }
                }
                rewardSystemDataAccess.SaveTransactionsBulk(transactions);
                rewardSystemDataAccess.SaveCustomerAndTransactionsBulk(new_customers);
            }
        }
    }
}
