// See https://aka.ms/new-console-template for more information
using RetailRewardSystem.BAL;
using RetailRewardSystem.Common;

Console.WriteLine("Hello, World!");

RewardSystemBusinessLogic rewardSystemBusinessLogic = new RewardSystemBusinessLogic();

Customer customer = new Customer();
customer.Name = "Anup";

Transaction transaction = new Transaction();
transaction.Date = DateTime.Now.Date;
transaction.PurchaseAmount = 126;

List<Transaction> transactions = new List<Transaction>();
transactions.Add(transaction);

rewardSystemBusinessLogic.SaveTransactions(
    new CustomerTransactions
    {
        Customer = customer,
        Transactions = transactions
    }
    );
