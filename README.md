# RetailRewardSystem
Tech stacks used : ASP.NET Core, ASP.NET WEP API, Entity Framework Core, SQL DataBase

The project has a web project, which has API's required. SaveTransaction, saves data to DB. GetRewards gets the rewards from db and calulates and gives it.
Calculate Reward, calculates rewards on fly.

The project has two API's SaveTransaction and GetReward to save transaction and to get rewards later, this is to make sure if there are more trasactions happening in a day, it is better to have the reward calculation done seperately. To achieve this, a background job which is a Console application is present.

Client can Save Transaction by giving data, background job which will constantly be running will calculate the reward and save it to DB. GetRewards can retrieve the calculated reward.
