CREATE TABLE [dbo].[Transactions] (
    [Id]             INT    IDENTITY (1, 1) NOT NULL,
    [Date]           DATE   NOT NULL,
    [CustomerId]     INT    NOT NULL,
    [PurchaseAmount] BIGINT NOT NULL,
    [RewardPoints]   BIGINT NULL
)

