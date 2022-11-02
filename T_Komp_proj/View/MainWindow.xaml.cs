using Microsoft.Data.SqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using T_Komp_proj.Helpers;
using static T_Komp_proj.DAL.dbOperations;


namespace T_Komp_proj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool isLoginSuccess = false;

        public MainWindow()
        {
            InitializeComponent();
            ButtonGetData.IsEnabled = false;
            tableInfo.Visibility = Visibility.Hidden;

        }


        #region BUTTONS
        private void ButtonTestConnection_Click(object sender, RoutedEventArgs e)
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(Properties.Settings.Default.cn);


            builder.UserID = usernameInput.Text;
            builder.Password = passwordInput.Password;

            //Save connection string to settings properties
            DataAccess.Set_DB_Connection_String(builder);


            if (Test_DB_Connection())
            {
                ButtonGetData.IsEnabled = true;
                isLoginSuccess = true;
                disableForm();
                setConnectButtonStyleToConnected();
                
            }
        }

        private void setConnectButtonStyleToConnected()
        {
            ButtonTestConnection.Content = "☑️ Połączono";
            ButtonTestConnection.Style = (Style)Application.Current.Resources["buttonStyleSuccess"];
            ButtonTestConnection.IsEnabled = false;
        }

        private void disableForm()
        {
            usernameInput.IsEnabled = false;
            passwordInput.IsEnabled = false;
        }

        private void ButtonGetData_Click(object sender, RoutedEventArgs e)
        {
            if (isLoginSuccess)
            {
                tableInfo.ItemsSource = Get_INT_Column_Names();
                tableInfo.Visibility = Visibility.Visible;
            }



        }
        #endregion


    }
}
