using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace CarBuy_v2._0
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        public Options()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

 
        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            
            //update account SET theme = "red" where idAccount = 1;
            var app = (App)Application.Current;

            ComboBoxItem theme = (ComboBoxItem)themeSelected.SelectedItem;
            ComboBoxItem language = (ComboBoxItem)languageSelected.SelectedItem;



            if(theme.Content.ToString().Equals("Default") && language.Content.ToString().Equals("English"))
            {
                MainWindow.loggedUser.Theme = "Default";
                MainWindow.language = "English";
                app.ChangeTheme(new Uri("Styles/DefaultStyle.xaml", UriKind.Relative));
            }
            else if(theme.Content.ToString().Equals("Blue") && language.Content.ToString().Equals("English"))
            {
                MainWindow.loggedUser.Theme = "Blue";
                MainWindow.language = "English";
                app.ChangeTheme(new Uri("Styles/BlueStyle.xaml", UriKind.Relative));
            }
            else if(theme.Content.ToString().Equals("Red") && language.Content.ToString().Equals("English"))
            {
                MainWindow.loggedUser.Theme = "Red";
                MainWindow.language = "English";
                app.ChangeTheme(new Uri("Styles/RedStyle.xaml", UriKind.Relative));
            }
            else if (theme.Content.ToString().Equals("Default") && language.Content.ToString().Equals("Serbian"))
            {
                MainWindow.loggedUser.Theme = "Default";
                MainWindow.language = "Serbian";
                app.ChangeTheme(new Uri("Styles/DefaultStyleSerbian.xaml", UriKind.Relative));
            }
            else if (theme.Content.ToString().Equals("Blue") && language.Content.ToString().Equals("Serbian"))
            {
                MainWindow.loggedUser.Theme = "Blue";
                MainWindow.language = "Serbian";
                app.ChangeTheme(new Uri("Styles/BlueStyleSerbian.xaml", UriKind.Relative));
            }
            else if (theme.Content.ToString().Equals("Red") && language.Content.ToString().Equals("Serbian"))
            {
                MainWindow.loggedUser.Theme = "Red";
                MainWindow.language = "Serbian";
                app.ChangeTheme(new Uri("Styles/RedStyleSerbian.xaml", UriKind.Relative));
            }



            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = @"update account SET theme = @theme where idAccount = @id";

                cmd.Parameters.AddWithValue("@theme", theme.Content.ToString().ToLower());
                cmd.Parameters.AddWithValue("@id", MainWindow.loggedUser.Id);

                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.StackTrace);
            }



        }

        private void LanguageChange(object sender, RoutedEventArgs e)
        {
            if(languageSelected.SelectedIndex==0)
            {
                Properties.Settings.Default.languageCode = "en-US";
            }
            else
            {
                Properties.Settings.Default.languageCode = "sr-RS";
            }
            Properties.Settings.Default.Save();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
