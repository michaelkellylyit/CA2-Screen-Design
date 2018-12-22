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
using System.Windows.Shapes;

namespace CA2_Screen_Design_UI
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        CaProjectEntities db = new CaProjectEntities("metadata=res://*/CaProjectModel.csdl|res://*/CaProjectModel.ssdl|res://*/CaProjectModel.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.1.8;initial catalog=CA3-Project-Database-L00137447;user id=MichaelKelly;password=303808909m@;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.Username = tbxUsername.Text.Trim();
            user.Firstname = tbxFirstname.Text.Trim();
            user.Surname = tbxSurname.Text.Trim();
            user.Email = tbxEmail.Text.Trim();
            user.Password = tbxPassword.Text.Trim();
            user.Password = tbxReenterPassword.Text.Trim();
            user.LevelID = (2);
            SaveUser(user);
            MessageBox.Show("Registration Complete");
            this.Close();

        }
        public void SaveUser(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges(); 
        }

        private void BtnResetPassword_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnBackToLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
           
        }
    }
}
