CREATE TABLE [dbo].[Transaction]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATE NOT NULL, 
    [CustomerId] INT NOT NULL FOREIGN KEY REFERENCES Customer(Id), 
    [PurchaseAmount] BIGINT NOT NULL, 
    [RewardPoints] BIGINT NULL
)
