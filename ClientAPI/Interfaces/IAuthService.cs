using ClientAPI.ModelApi;

namespace ClientAPI.Interfaces
{
    public interface IAuthService
    {
        string Aut(UserAuthorizationRequst userAuthorization);
        bool ChekTokkent(string tokken);
    }
}