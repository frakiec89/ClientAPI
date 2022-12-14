using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ClientAPI.Interfaces;
using ClientAPI.ModelApi;
using Newtonsoft.Json;

namespace ClientAPI.ServiceApi
{
    internal class AuthService : IAuthService
    {

        private IApiService _apiService = App.GetApiService;

        public string Aut(UserAuthorizationRequst userAuthorization)
        {
            try
            {
                if (_apiService.ValidateConnection() == true)
                {
                    string jsonuserAuthorization = JsonConvert.SerializeObject(userAuthorization);
                    var resualt = _apiService.Post("/api/Auth/aut", jsonuserAuthorization);
                    return resualt.ToString();
                }
                else
                {
                    throw new Exception("Апи не  доступна");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public bool ChekTokkent(string tokken)
        {

            try
            {
               var res =   _apiService.PostOnHider("/api/Auth/ChekTokken", tokken);
               if( Convert.ToBoolean(res)==true)
                    return  true;
               else 
                    return false;
            }
            catch (Exception ex)
            {
                throw; new Exception(ex.Message);
            }

         
        }
    }
}
