using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientAPI.Interfaces;
using Newtonsoft.Json;

namespace ClientAPI.ServiceApi
{
    public class UserService : IUserService
    {

        private IApiService _apiService = App.GetApiService;


        public void AddUser (ModelApi.NewUserRequst userRequst)
        {
            try
            {
                var content = JsonConvert.SerializeObject(userRequst);
                _apiService.Post("/api/RegistrationUser/registration", content);

            }
            catch (Exception ex)
            {
                throw new Exception(  ex.Message );
            }
               
        }

    }
}
