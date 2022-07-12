using RetailRewardSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailRewardSystem.DAL
{
    public interface IRewardSystemDataAccess
    {
        public List<Transaction> GetTransactions();
        public void SaveTransactions(Customer customer);
        public void SaveTransactionsBulk(List<Transaction> transactions);
        public void SaveCustomerAndTransactionsBulk(List<Customer> customers);
        bool IsCustomerPresent(Customer customer);
        List<Transaction> GetTransactions(Customer customer);
    }
}
