using Social_Network.Core.Entities;
using Social_Network.Core.Interfaces.IRepositories.Base;

namespace Social_Network.Core.Interfaces.IRepositories
{
    public interface IUsersRepository : IRepository<User>
    {
        User GetUserByLogin(string login);

        bool CheckUser(string login, string password);

        bool IsLoginFree(string login);
    }
}
