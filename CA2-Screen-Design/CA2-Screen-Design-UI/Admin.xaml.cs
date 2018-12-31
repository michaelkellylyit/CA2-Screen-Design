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

        // Database lists
        List<User> users = new List<User>();
        List<Log> logs = new List<Log>();
        List<Project> projects = new List<Project>();
        User selectedUser = new User();
        private object tbxUserFirstname;
        private string tbxSurname;

        enum DBOperation
        {
            Add,
            Modify,
            Delete
        }
        DBOperation dbOperation = new DBOperation();
        private AnalysisType analysisType;
        private ChooseTable chooseTable;
        private int recordCount;
        private readonly object tbxAnalysisOutput;

        enum AnalysisType
        {
            Summary,
            Count,
            Statistics
        }

        enum ChooseTable
        {
            Project,
            User,
            Log
        }
        public Admin()
        {
            InitializeComponent();
        }


        // Loads and displays user , project and logs lists once page is opened
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

            foreach (var project in db.Projects)
            {
                projects.Add(project); 
            }
        }

        // Used to enable right click options
        private void LstUserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstUserList.SelectedIndex > 0)
            {
                selectedUser = users.ElementAt(lstUserList.SelectedIndex);
                
                    submenuModifySelectedUser.IsEnabled = true;
                    submenuDeleteSelectedUser.IsEnabled = true;
                    tbxUsername.Text = selectedUser.Username;
                
            }
            
        }

        // Refreshs the user list display
        private void RefreshUserList()
        {
            lstUserList.ItemsSource = users;
            users.Clear();
            foreach (var user in db.Users)
            {
                users.Add(user);
            }
            lstUserList.Items.Refresh();
        }

        //Clears combobox
        private void ClearUserInfo()
        {
            tbxUsername.Text = "";
        }

       
        // Not currently used, but left in as a future option
        private void SubmenuModifySelectedUser_Click(object sender, RoutedEventArgs e)
        {
            dbOperation = DBOperation.Modify; 
        }

        // Operation for removing user accounts from the system and SQL database
        private void SubmenuDeleteSelectedUser_Click(object sender, RoutedEventArgs e)
        {
            // Only removes users that have been selected and saves changes
            db.Users.RemoveRange(db.Users.Where(t => t.UserID == selectedUser.UserID));
            int saveSuccess = db.SaveChanges();
            if (saveSuccess == 1)
            {
                // Conformation of account removal and user list refreshed
                MessageBox.Show("Account Deleted", "Delete From Database", MessageBoxButton.OK, MessageBoxImage.Information);
                RefreshUserList();
                ClearUserInfo();
            }
            else
            {
                // Error message to indicate a problem with removing user 
                MessageBox.Show("Cannot Delete Account", "Delete From Database", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CboChooseTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            // Check that an option has been selected.
            // The default selection will remain as please select if no option selected
            if (cboChooseTable.SelectedIndex > 0)
            {
                if (cboChooseTable.SelectedIndex == 1)
                {
                    chooseTable = ChooseTable.Project;
                }
                if (cboChooseTable.SelectedIndex == 2)
                {
                    chooseTable = ChooseTable.User;
                }
                if (cboChooseTable.SelectedIndex == 3)
                {
                    chooseTable = ChooseTable.Log;
                }

            }
        }
        

        private void CboAnalysisType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check that an option has been selected.
            // The default selection will remain as please select if no option selected
            if (cboAnalysisType.SelectedIndex > 0)
            {
                if (cboAnalysisType.SelectedIndex == 1)
                {
                    analysisType = AnalysisType.Summary;
                }
                if (cboAnalysisType.SelectedIndex == 2)
                {
                    analysisType = AnalysisType.Count;
                }
                if (cboAnalysisType.SelectedIndex == 3)
                {
                    analysisType = AnalysisType.Statistics;
                }
            }
        }

        private void BtnAnalyze_Click(object sender, RoutedEventArgs e)
        {
            // Clear Variables. 
            // Project count shows number of projects on system
            int projectCount = 0;
            string output = "";
            tbkAnalysis.Text = "";
            if (analysisType == AnalysisType.Summary && chooseTable == ChooseTable.Project)
            {
                foreach (var item in projects)
                {
                    // Increment count
                    recordCount++;
                    output = output + Environment.NewLine + $"Record {recordCount} for projects named {item.ProjectName}" + Environment.NewLine;
                }
                output = output + Environment.NewLine + $"total number of records = {recordCount}" + Environment.NewLine;
                tbkAnalysis.Text = output; 
            }
            if (analysisType == AnalysisType.Summary && chooseTable == ChooseTable.User)
            {
                int level1CountSummary = 0;
                int level2CountSummary = 0;
                foreach (var item in users)
                {
                    recordCount++;
                    output = output + Environment.NewLine + $"record {recordCount} is for the user" +
                        $"whose name is {item.Firstname}, {item.Surname}, with username {item.Username}. This" +
                        $"user has access level {item.LevelID} which is for {item.AccessLevel.UserType} usertype" +
                        $"role." + Environment.NewLine;

                    if (item.LevelID == 1)
                    {
                        level1CountSummary++;
                    }
                    if (item.LevelID == 2)
                    {
                        level2CountSummary++;
                    }
                }
                output = output + Environment.NewLine + $"Total users with level 1 access is {level1CountSummary}." +
                    Environment.NewLine;
                output = output + Environment.NewLine + $"Total users with level 2 access is {level2CountSummary}." +
                    Environment.NewLine;
                output = output + Environment.NewLine + $"total number of records = {recordCount}";
                tbkAnalysis.Text = output;
            }
            if (analysisType == AnalysisType.Summary && chooseTable == ChooseTable.Log)
            {
                foreach (var item in logs)
                {
                    recordCount++;
                    output = output + Environment.NewLine + $"Record {recordCount} is for Log" +
                        $"created by {item.User.Firstname}, {item.User.Surname} whose user " +
                        $"ID is {item.UserID}. Log was created on {item.Date}. " +
                        $"This log is registered for the {item.Category} category. " +
                        $"The description of this log is {item.Description}" + Environment.NewLine;
                    output = output + Environment.NewLine + $"total number of records = {recordCount}";
                    tbkAnalysis.Text = output;
                }
            }
        }   

    }
}
