// See https://aka.ms/new-console-template for more information
using RetailRewardSystem.BAL;
using RetailRewardSystem.Common;

Console.WriteLine("Retail reward system started running");
RewardSystemBusinessLogic rewardSystemBusinessLogic = new RewardSystemBusinessLogic();
for (; ; )
{
    Console.WriteLine("Set up initial data Y/N ? : ");
    string? input = Console.ReadLine();
    switch (input)
    {
        case "Y":
        case "y":
            InitDataSetUp();
            RunJob();
            break;
        case "N":
        case "n":
            RunJob();
            break;
        default:
            Console.WriteLine("Wrong selection, please try again...!!");
            break;
    }
}

void RunJob()
{
    for (; ; )
    {
        var transactions = rewardSystemBusinessLogic.GetTransactions();

        if (transactions != null && transactions.Count > 0)
        {
            foreach (var transaction in transactions)
            {
                if (transaction.Customer.Transactions != null && transaction.Customer.Transactions.Count > 0)
                {
                    foreach (var tran in transaction.Customer.Transactions)
                    {
                        if (tran.RewardPoints == null)
                        {
                            if (tran.PurchaseAmount > 50 && tran.PurchaseAmount <= 100)
                            {
                                tran.RewardPoints = tran.PurchaseAmount - 50;
                            }
                            else if(tran.PurchaseAmount >= 100)
                            {
                                tran.RewardPoints = (tran.PurchaseAmount - 50) + (tran.PurchaseAmount - 100);
                            }
                        }
                    }
                }
            }
            rewardSystemBusinessLogic.SaveTransactionsBulk(transactions);
        }
    }
}

void InitDataSetUp()
{
    List<Transaction> transactions = new List<Transaction>();
    
    Customer customer = new Customer();
    customer.Id = 1;
    customer.Name = "Anup";

    Transaction transaction = new Transaction();
    transaction.Date = new DateTime(2022,4,7);
    transaction.PurchaseAmount = 126;
    transaction.Id = 1;
    customer.Transactions.Add(transaction);

    transaction.Date = new DateTime(2022, 4, 15);
    transaction.PurchaseAmount = 200;
    transaction.Id = 2;
    customer.Transactions.Add(transaction);

    transaction.Date = new DateTime(2022, 4, 26);
    transaction.PurchaseAmount = 150;
    transaction.Id = 3;
    customer.Transactions.Add(transaction);

    transaction.Date = new DateTime(2022, 5, 5);
    transaction.PurchaseAmount = 45;
    transaction.Id = 4;
    customer.Transactions.Add(transaction);

    transaction.Date = new DateTime(2022, 5, 15);
    transaction.PurchaseAmount = 58;
    transaction.Id = 5;
    customer.Transactions.Add(transaction);

    transaction.Date = new DateTime(2022, 5, 28);
    transaction.PurchaseAmount = 01;
    transaction.Id = 6;
    customer.Transactions.Add(transaction);

    transaction.Date = new DateTime(2022, 6, 25);
    transaction.PurchaseAmount = -25;
    transaction.Id = 7;
    customer.Transactions.Add(transaction);

    transaction.Date = new DateTime(2022, 7, 8);
    transaction.PurchaseAmount = 128;
    transaction.Id = 8;
    customer.Transactions.Add(transaction);
    
    List<CustomerTransactions> ct = new List<CustomerTransactions>();
    ct.Add(new CustomerTransactions() { Customer = customer });
    rewardSystemBusinessLogic.SaveTransactionsBulk(ct);
}

