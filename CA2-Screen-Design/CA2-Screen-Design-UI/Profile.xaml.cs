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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        CaProjectEntities db = new CaProjectEntities("metadata=res://*/CaProjectModel.csdl|res://*/CaProjectModel.ssdl|res://*/CaProjectModel.msl;provider=System.Data.SqlClient;provider connection string='data source=192.168.1.8;initial catalog=CA3-Project-Database-L00137447;user id=MichaelKelly;password=303808909m@;pooling=False;MultipleActiveResultSets=True;App=EntityFramework'");
        List<Genre> genresList = new List<Genre>();
        List<Favourite> favourites = new List<Favourite>();
        List<UserProfile> userProfiles = new List<UserProfile>();
        Project selectedProject = new Project();
        public Profile()
        {
            InitializeComponent();
        }

        enum DBOperation
        {
            Add,
            Modify
        }
        DBOperation dbOperation = new DBOperation();

        //Refreshes the genre list
        //Populates genre selection combobox
        private void RefreshGenreList()
        {
            genresList.Clear();
            foreach (var genreRecord in db.Genres)
            {
                genresList.Add(genreRecord);
            }
            cboGenre.ItemsSource = genresList;
            cboGenre.Items.Refresh();
        }
        // 
        private void RefreshFavouritesList()
        {
            favourites.Clear();
            foreach (var favouriteRecord in db.Favourites)
            {
                favourites.Add(favouriteRecord);
            }
            cboFavourites.ItemsSource = favourites;
            cboFavourites.Items.Refresh();
        }

        //Populates and refreshes the favourite user list.
        private void RefreshFavouriteListView()
        {
            favourites.Clear();
            foreach (var favouriteRecord in db.Favourites)
            {
                favourites.Add(favouriteRecord);
            }
            lstFavourites.ItemsSource = favourites;
            lstFavourites.Items.Refresh();
        }

        //Populates and refreshes the choosen genre list.
        private void RefreshGenreListView()
        {
            genresList.Clear();
            foreach (var genreRecord in db.Genres)
            {
                genresList.Add(genreRecord);
            }
            lstGenre.ItemsSource = genresList;
            lstGenre.Items.Refresh();
        }

        // Populates and refreshes the user bio.
        private void RefreshUserBioView()
        {
            userProfiles.Clear();
            foreach (var profileRecord in db.UserProfiles)
            {
                userProfiles.Add(profileRecord);
            }
            lstUserBio.ItemsSource = userProfiles;
            lstUserBio.Items.Refresh();
        }



        //Validate Text input.
        //private bool ValidateProfileInput()
        //{
        //    bool validated = true;

        //    if (tbxBio.Text.Length == 0 || tbxBio.Text.Length > 250)
        //    {
        //        validated = false;
        //    }
        //    return validated; 
        //}


        

        // Loads all page lists.
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshGenreList();
            RefreshFavouritesList();
            RefreshFavouriteListView();
            RefreshGenreListView();

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            dbOperation = DBOperation.Modify;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            dbOperation = DBOperation.Add;
        }

        private void LstUserBio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnUpload1_Click(object sender, RoutedEventArgs e)
        {
            // Open File dialog
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            // file extension type filter
            dialog.DefaultExt = ".rar";
            dialog.Filter = ".rar files (*.rar)|*.rar";
            // Display OpenFileDialog by calling show ShowDialog method
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                MessageBox.Show("Uploaded"); 
            }

        }

        private void BtnUpload2_Click(object sender, RoutedEventArgs e)
        {
            // Open File dialog
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            // file extension type filter
            dialog.DefaultExt = ".rar";
            dialog.Filter = ".rar files (*.rar)|*.rar";
            // Display OpenFileDialog by calling show ShowDialog method
            bool? result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                MessageBox.Show("Uploaded");
            }
        }
        private void BtnCreateProj2_Click(object sender, RoutedEventArgs e)
        {
            btnUpload2.Visibility = Visibility.Visible;
            btnDownload2.Visibility = Visibility.Visible;
        }

        private void BtnCreateproj1_Click(object sender, RoutedEventArgs e)
        {
            btnUpload1.Visibility = Visibility.Visible;
            btnDownload1.Visibility = Visibility.Visible;
        }

        private void btnEdit1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
