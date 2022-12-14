using ClientAPI.ModelApi;

namespace ClientAPI.Interfaces
{
    public interface IUserService
    {
        void AddUser(NewUserRequst userRequst);
    }
}