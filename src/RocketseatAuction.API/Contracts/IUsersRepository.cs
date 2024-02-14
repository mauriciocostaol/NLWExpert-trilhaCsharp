using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contracts;

public interface IUsersRepository
{
    bool ExistUserWithEmail(string email);
    public User GetUserByEmail(string email);
}
