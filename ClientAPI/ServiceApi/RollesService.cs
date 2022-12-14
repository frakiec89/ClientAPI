using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientAPI.Interfaces;
using Newtonsoft.Json;

namespace ClientAPI.ServiceApi
{
    public class RollesService : IRollesService
    {
        IAuthService _authService = App.GetIAuthService;
        IApiService _apiService = App.GetApiService;

        public List<string> GetRolles(string tokken)
        {

            try
            {
                if (_authService.ChekTokkent(tokken) == false)
                {
                    App.Tokken = _authService.Aut(new ModelApi.UserAuthorizationRequst
                    { login = App.Login, password = App.Pasword }
                     );
                }

                var res =  _apiService.GetOnHider("/api/RegistrationUser/GetListRole", tokken);

              return   JsonConvert.DeserializeObject<List<string>>(res);

            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
          
        }
    }
}
