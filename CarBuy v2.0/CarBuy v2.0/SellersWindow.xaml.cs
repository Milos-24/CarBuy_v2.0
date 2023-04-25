using CarBuy_v2._0.Models;
using MySql.Data.MySqlClient;
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
    /// Interaction logic for SellersWindow.xaml
    /// </summary>
    public partial class SellersWindow : Window
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        public List<Car> cars;
        public List<SellersCarForm> carsForms;


        public SellersWindow()
        {
            InitializeComponent();
            cars = new List<Car>();
            carsForms = new List<SellersCarForm>();
            MainWindow.language = "English";
            LoadCars();
            LoadTheme();
        }

        private void LoadCars()
        {
            cars.Clear();
            carsForms.Clear();
            carsStackPanel.Children.Clear();
            

            string name = MainWindow.loggedUser.Name;

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = @"select * from vehicle inner join model using (idModel) " +
                    "inner join brandname using (idBrandName)" +
                    "inner join account using (idAccount) where username=@username and removed=0;";
                cmd.Parameters.AddWithValue("@username", name);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cars.Add(new Car(MainWindow.loggedUser.Id, reader.GetInt32(14), reader.GetInt32(5),
                        reader.GetInt32(6), reader.GetString(8),
                        reader.GetString(7), reader.GetInt32(4), reader.GetString(10), reader.GetInt32(3),
                        reader.GetString(15), reader.GetString(16), reader.GetInt32(11)));
                }

                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.StackTrace);
            }


            foreach (Car car in cars)
            {
                SellersCarForm form = new SellersCarForm(this, car);
                carsForms.Add(form);
                carsStackPanel.Children.Add(form);
            }


        }
        private void LoadTheme()
        {
            var app = (App)Application.Current;


            if (MainWindow.loggedUser.Theme.Equals("default") && MainWindow.language.Equals("English"))
            {
                app.ChangeTheme(new Uri("Styles/DefaultStyle.xaml", UriKind.Relative));
            }
            else if (MainWindow.loggedUser.Theme.Equals("blue") && MainWindow.language.Equals("English"))
            {
                app.ChangeTheme(new Uri("Styles/BlueStyle.xaml", UriKind.Relative));
            }
            else if (MainWindow.loggedUser.Theme.Equals("red") && MainWindow.language.Equals("English"))
            {
                app.ChangeTheme(new Uri("Styles/RedStyle.xaml", UriKind.Relative));
            }
            
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;

        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            options.Show();
        }
        private async void RefreshButtonClick(object sender, RoutedEventArgs e)
        {
            carsStackPanel.Children.Clear();
            cars.Clear();

            //await Task.Delay(1000);

            LoadCars();

        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {

            carsForms.Clear();
            carsStackPanel.Children.Clear();

            List<Car> searchedCars = new List<Car>();

            if (SearchText.Text.Equals(""))
            {
                LoadCars();
            }
            else
            {
                foreach (Car car in cars)
                {
                    
                    if (String.Equals(car.CarBrand, SearchText.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        searchedCars.Add(car);
                    }
                    else if (String.Equals(car.Model, SearchText.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        searchedCars.Add(car);
                    }
                }
            }




            foreach (Car car in searchedCars)
            {
                SellersCarForm form = new SellersCarForm(this, car);
                carsForms.Add(form);
                carsStackPanel.Children.Add(form);
            }

        }


        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            AddCar addCar = new AddCar();
            addCar.Show();
        }

    }
}
