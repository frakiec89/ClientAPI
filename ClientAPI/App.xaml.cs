using ClientAPI.Interfaces;
using ClientAPI.ServiceApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ClientAPI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IApiService? GetApiService { get; set; }  = new ApiService();
        public static IAuthService? GetIAuthService { get; set; } = new AuthService();
        public static IUserService? GetUserService { get; set; } = new UserService();
        public static IRollesService? GetRollesService { get;  set; } = new RollesService();

        public static string Tokken { get; set; }


        public static string Login { get; set; }
        public static string Pasword { get; set; }
       
    }
}
