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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public User user = new User();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CboSearchBrowse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void CheckUserAccess(User user)
        {
            if (user.LevelID == 1)
            {
                mnuAdminMenu.Visibility = Visibility.Visible;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CheckUserAccess(user);
        }

        private void BtnAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MnuLogs_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Menu option is checked");
        }

        private void MnuUsers_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Menu option is checked");
        }


        private void MnuAdminControl_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            frmMain.Navigate(admin);
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile();
            frmMain.Navigate(profile);
        }
    }
}
