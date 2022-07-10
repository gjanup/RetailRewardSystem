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
            rewardSystemBusinessLogic.SaveTransactionsBulk(transactions);
        }
        else
        { 
            Thread.Sleep(60000);
        }
    }
}

void InitDataSetUp()
{
    List<Transaction> transactions = new List<Transaction>();
    
    Customer customer = new Customer();
    customer.Name = "Anup";

    Transaction transaction = new Transaction();
    transaction.Date = new DateTime(2022,4,7);
    transaction.PurchaseAmount = 126;
    customer.Transactions.Add(transaction);

    Transaction transaction1 = new Transaction();
    transaction1.Date = new DateTime(2022, 4, 15);
    transaction1.PurchaseAmount = 200;
    customer.Transactions.Add(transaction1);

    //transaction.Date = new DateTime(2022, 4, 26);
    //transaction.PurchaseAmount = 150;
    //transaction.Id = 3;
    //customer.Transactions.Add(transaction);

    //transaction.Date = new DateTime(2022, 5, 5);
    //transaction.PurchaseAmount = 45;
    //transaction.Id = 4;
    //customer.Transactions.Add(transaction);

    //transaction.Date = new DateTime(2022, 5, 15);
    //transaction.PurchaseAmount = 58;
    //transaction.Id = 5;
    //customer.Transactions.Add(transaction);

    //transaction.Date = new DateTime(2022, 5, 28);
    //transaction.PurchaseAmount = 01;
    //transaction.Id = 6;
    //customer.Transactions.Add(transaction);

    //transaction.Date = new DateTime(2022, 6, 25);
    //transaction.PurchaseAmount = -25;
    //transaction.Id = 7;
    //customer.Transactions.Add(transaction);

    //transaction.Date = new DateTime(2022, 7, 8);
    //transaction.PurchaseAmount = 128;
    //transaction.Id = 8;
    //customer.Transactions.Add(transaction);

    List<Customer> ct = new List<Customer>(); 
    ct.Add(customer);
    //ct.Add(new CustomerTransactions() { Customer = customer });
    rewardSystemBusinessLogic.SaveCustomerAndTransactionsBulk(ct);
}

