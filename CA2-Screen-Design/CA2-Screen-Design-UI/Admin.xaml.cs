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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        CaProjectEntities db = new CaProjectEntities("metadata=res://*/CaProjectModel.csdl|res://*/CaProjectModel.ssdl|res://*/CaProjectModel.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.1.8;initial catalog=CA3-Project-Database-L00137447;user id=MichaelKelly;password=303808909m@;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");

        List<User> users = new List<User>();
        List<Log> logs = new List<Log>();
        public Admin()
        {
            InitializeComponent();
        }

        private void SubmenuDeleteSelectedUser_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            lstUserList.ItemsSource = users;
            lstLogList.ItemsSource = logs;
            foreach (var user in db.Users)
            {
                users.Add(user);
            }

            foreach (var log in db.Logs)
            {
                logs.Add(log);
            }
        }
    }
}
