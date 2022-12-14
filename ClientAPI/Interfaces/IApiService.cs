namespace ClientAPI.Interfaces
{
    public interface IApiService
    {
        string GetHello(string url, string name);
        string GetOnHider(string url , string tokken);
        string  Post(string url , string jsonContent);
        string PostOnHider(string url , string tokken);
        bool ValidateConnection();
    }
}