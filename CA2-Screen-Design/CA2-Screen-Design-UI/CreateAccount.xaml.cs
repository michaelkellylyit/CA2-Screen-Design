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
        User selectedUser = new User();
        public CreateAccount()
        {
            InitializeComponent();
        }

        //Operation for adding and modifying input data
        enum DBOperation
        {
            Add,
            Modify,
            Delete
        }
        DBOperation dbOperation = new DBOperation();

        // Validate the following inputs to assure data is saved to the SQL database correctly without error
        private bool ValidateAccountInput()
        {
            bool validated = true;
            if (tbxUsername.Text.Length == 0 || tbxUsername.Text.Length > 30)
            {
                validated = false;
            }
            if (tbxFirstname.Text.Length == 0 || tbxFirstname.Text.Length > 30)
            {
                validated = false;
            }
            if (tbxSurname.Text.Length == 0 || tbxSurname.Text.Length > 30)
            {
                validated = false;
            }
            if (tbxEmail.Text.Length == 0 || tbxEmail.Text.Length > 30)
            {
                validated = false;
            }
            if (tbxPassword.Text.Length == 0 || tbxPassword.Text.Length > 30)
            {
                validated = false;
            }
            if (tbxReenterPassword.Text.Length == 0 || tbxReenterPassword.Text.Length > 30)
            {
                validated = false;
            }
            return validated;
        }

        // Create new user account
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            // The following must added to database to create a new account
            if (dbOperation == DBOperation.Add)
            {
                User user = new User();
                user.Username = tbxUsername.Text.Trim();
                user.Firstname = tbxFirstname.Text.Trim();
                user.Surname = tbxSurname.Text.Trim();
                user.Email = tbxEmail.Text.Trim();
                user.Password = tbxPassword.Text.Trim();
                user.Password = tbxReenterPassword.Text.Trim();
                user.LevelID = (2);

                // Save new user to database if
                int accountCreated = SaveUser(user);
                if (accountCreated == 1)
                {
                    // If successful show the following message
                    MessageBox.Show("Account Created, Please return to Login", "Save to Database", MessageBoxButton.OK, MessageBoxImage.Information);
                    ClearAccountInfo();
                }
                else
                {
                    // If there is a problem with the details entered then show this message
                    MessageBox.Show("There was a problem, please check your details", "Save to Database", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            //if (dbOperation == DBOperation.Modify)
            //{
            //    foreach (var user in db.Users.Where(t => t.UserID == selectedUser.UserID))
            //    {
            //        user.Username = tbxUsername.Text.Trim();
            //        user.Firstname = tbxFirstname.Text.Trim();
            //        user.Surname = tbxSurname.Text.Trim();
            //        user.Email = tbxEmail.Text.Trim();
            //        user.Password = tbxPassword.Text.Trim();
            //        user.Password = tbxReenterPassword.Text.Trim();
            //        user.LevelID = (2);
            //    }
            //    int saveSuccess = db.SaveChanges();
            //    if (saveSuccess == 1)
            //    {
            //        MessageBox.Show("Account Modified", "Save to Database", MessageBoxButton.OK, MessageBoxImage.Information);
            //        ClearAccountInfo();
            //    }
            //}
        }

        
        // New user account saved to database
        public int SaveUser(User user)
        {
            db.Entry(user).State = System.Data.Entity.EntityState.Added;
            int accountCreated = db.SaveChanges();
            return accountCreated;
        }

        // Clear textboxes
        private void ClearAccountInfo()
        {
            tbxUsername.Text = "";
            tbxFirstname.Text = "";
            tbxSurname.Text = "";
            tbxPassword.Text = "";
            tbxReenterPassword.Text = "";
            tbxEmail.Text = "";
        }

        private void BtnResetPassword_Click(object sender, RoutedEventArgs e)
        {

        }

        // Allow user to return to login screen and close create account window
        private void BtnBackToLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
           
        }
    }
}
