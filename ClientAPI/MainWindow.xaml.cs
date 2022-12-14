using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private Interfaces.IApiService _apiService;

        private Interfaces.IAuthService _authService;

        private Interfaces.IRollesService _rollesService;
        

        public MainWindow()
        {
            InitializeComponent();
            _apiService = App.GetApiService;
            _authService = App.GetIAuthService;
            _rollesService = App.GetRollesService;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_apiService.ValidateConnection())
                    MessageBox.Show("Апи готово к  использованию ");
                else
                    MessageBox.Show("Апи не готово  к  использованию");
            }
            catch (Exception ex )
            {
                MessageBox.Show("хс вообще " + ex.Message);

            }
           
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.Login = tbLogin.Text;
                App.Pasword = tbPassword.Text;

                App.Tokken = _authService.Aut(new ModelApi.UserAuthorizationRequst
                {
                    login = App.Login, 
                    password = App.Pasword
                });

                MessageBox.Show("ваш токен " + App.Tokken);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if(App.Tokken == null)
            {
                MessageBox.Show("Сначала авторизуйтесь");
                return;
            }

            try
            {
               var bull =   _authService.ChekTokkent(App.Tokken);
                if (bull == true)
                    MessageBox.Show("Токенн действеут");
                else
                    MessageBox.Show("Токкен не  действует");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddUserWindow window = new AddUserWindow();
            window.ShowDialog();
        }

        private void GetListRolle_Click(object sender, RoutedEventArgs e)
        {

            if (App.Tokken == null)
            {
                MessageBox.Show("Сначала авторизуйтесь");
                return;
            }

            try
            {
                foreach (var item in _rollesService.GetRolles(App.Tokken))
                {
                    MessageBox.Show(item);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
