using DatabaseLibrary;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_Screen_Design_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CaProjectEntities db = new CaProjectEntities("metadata=res://*/CaProjectModel.csdl|res://*/CaProjectModel.ssdl|res://*/CaProjectModel.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.1.8;initial catalog=CA3-Project-Database-L00137447;user id=MichaelKelly;password=303808909m@;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");
        public MainWindow()
        {
            InitializeComponent();
             


        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string currentUser = tbxUsername.Text;
            string currentPassword = tbxPassword.Password;
            foreach (var user in db.Users)
            {
                if (user.Username == currentUser && user.Password == currentPassword)
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Owner = this;
                    dashboard.ShowDialog();
                    dashboard.user = user;
                    this.Hide();
                }
                else
                {
                    lblErrorMessage.Content = "Check login credentials";
                }
            }
        }

        private void BtnCreateReset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }
    }
    }

