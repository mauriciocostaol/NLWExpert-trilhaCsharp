﻿using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAcess;

public class UsersRepository:IUsersRepository
{
    private readonly RocketseatAuctionDbContext _dbContext;
    public UsersRepository(RocketseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public bool ExistUserWithEmail(string email)
    {
       return _dbContext.Users.Any(user => user.Email.Equals(email));
    }

    public User GetUserByEmail(string email)
    {
       return _dbContext.Users.First(user => user.Email.Equals(email));
    }
}
