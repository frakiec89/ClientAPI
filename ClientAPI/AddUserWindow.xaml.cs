using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientAPI
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        Interfaces.IUserService _userService;

        private Interfaces.IApiService _apiService;
        public AddUserWindow()
        {
            InitializeComponent();
            _userService = App.GetUserService;
            _apiService = App.GetApiService;
        }

        private void btnIn_Click(object sender, RoutedEventArgs e)
        {

            if (_apiService.ValidateConnection() == false)
            {
                MessageBox.Show("апи не  доступно");
                return;
            }
            
            var  us = new  ModelApi.NewUserRequst ()
            { email = tbEmail.Text , login = tbLogin.Text , password = tbPassword.Text , userName = tbName.Text };

            try
            {
                _userService.AddUser(us);
                MessageBox.Show("пользователь добавлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
