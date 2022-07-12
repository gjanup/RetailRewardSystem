using Microsoft.AspNetCore.Mvc;
using RetailRewardSystem.BAL;
using RetailRewardSystem.Common;

namespace RetailRewardSystem.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RewardController : ControllerBase
    {
        IRewardSystemBusinessLogic rewardSystemBusinessLogic = new RewardSystemBusinessLogic();

        [HttpGet]
        public Customer GetRewards(Customer customer)
        { 
            return rewardSystemBusinessLogic.GetRewards(customer);
        }

        [HttpPost]
        public string SaveTransaction(IEnumerable<Customer> customers)
        {
            rewardSystemBusinessLogic.SaveTransactions(customers);
            return "Successfully saved";
        }

        [HttpPost]
        public IEnumerable<Customer> CalculateReward(IEnumerable<Customer> customers)
        {
            return rewardSystemBusinessLogic.CalculateReward(customers);
        }
    }
}
