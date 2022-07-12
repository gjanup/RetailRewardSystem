using RetailRewardSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailRewardSystem.BAL
{
    public interface IRewardSystemBusinessLogic
    {
        public void CalculateReward();

        public void SaveTransactions(IEnumerable<Customer> customers);

        public Customer GetRewards(Customer customer);

        public IEnumerable<Customer> CalculateReward(IEnumerable<Customer> customers);
    }
}
