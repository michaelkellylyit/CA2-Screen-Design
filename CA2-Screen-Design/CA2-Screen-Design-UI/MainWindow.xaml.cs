using DatabaseLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
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
            User validatedUser = new User();
            bool login = false;
            bool credentialsValidated = false;
            string currentUser = tbxUsername.Text;
            string currentPassword = tbxPassword.Password;
            credentialsValidated = ValidatedUserInput(currentUser, currentPassword); 
            if (credentialsValidated)
            {
                validatedUser = GetUserRecord(currentUser, currentPassword);
                if (validatedUser.UserID >0)
                {
                    CreateLogEntry("Login", "Login Successful.", validatedUser.UserID, validatedUser.Username);
                    Dashboard dashboard = new Dashboard
                    {
                        user = validatedUser,
                        Owner = this
                    };
                    dashboard.ShowDialog();
                    this.Hide();
                }
                else
                {
                    CreateLogEntry("Login", "Unsuccessful Login.", 0, currentUser);
                    MessageBox.Show("The credentials entered do not match any records on the system, create a new account or try again", "User Login");
                }
        
            }
            else
            {
                MessageBox.Show("Username & Password error, Please re-enter.", "User Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //if (login)
            //{
            //    CreateLogEntry("Login", "Login Successful.", validatedUser.UserID, validatedUser.Username);
            //    Dashboard dashboard = new Dashboard
            //    {
            //        user = validatedUser,
            //        Owner = this
            //    };
            //    dashboard.ShowDialog();
            //    this.Hide();
            //}
            //else
            //{
            //    CreateLogEntry("Login", "Unsuccessful Login.", 0, currentUser);
            //}
        }
        /// <summary>
        /// Validates user credentials against those in the database.
        /// </summary>
        /// <param name="username"></param>
        /// Username entered by user.
        /// <param name="password"></param>
        /// Password entered by user.
        /// <returns>
        /// Validated user.
        /// </returns>
        private bool ValidatedUserInput(string username, string password)
        {
            bool validated = true;
            if (username.Length == 0 || username.Length > 30)
            {
                validated = false;
            }
            // Check each character of username for a number
            // System does not allow numbers in username
            foreach (char ch in username)
            {
                if (ch >= '0' && ch <= '9')
                {
                    validated = false;
                }
            }
            // Password is required
            // Must be under 30 characters
            if (password.Length == 0 || password.Length >30)
            {
                validated = false;
            }
            return validated; 
        }
        /// <summary>
        /// Validates user credentials against those in database
        /// </summary>
        /// <param name="username"></param>
        /// Username entered by user
        /// <param name="password"></param>
        /// Password enetered by user
        /// <returns>
        /// Validated user
        /// </returns>
        private User GetUserRecord(string username, string password)
        {   User validatedUser = new User();
            try
            {
                //Gets username and password passed to method
                // From Users table in database
                
                foreach (var user in db.Users.Where(t => t.Username == username && t.Password == password))
                {
                    validatedUser = user;
                }
            }
            catch (EntityException)
            {
                MessageBox.Show("Problem connecting to server. Apllication will now shut down.", "Connect to Database", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                Environment.Exit(0);
            }
          
            return validatedUser;
        }

        private void CreateLogEntry(string category, string description, int userID, string userName) 
        {
            string comment = $"{description} user credentials = {userName}";
            Log log = new Log();
            log.UserID = userID;
            log.Category = category;
            log.Description = comment;
            log.Date = DateTime.Now;
            SaveLog(log);
        }
        

        private void SaveLog(Log log)
        {
            db.Entry(log).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
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

