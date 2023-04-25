using CarBuy_v2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows;
using System.Windows.Input;

namespace CarBuy_v2._0
{
    /// <summary>
    /// Interaction logic for BuyersWindow.xaml
    /// </summary>
    public partial class BuyersWindow : Window
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        public List<Car> cars;
        public List<CarForm> carsForms;

        public BuyersWindow()
        {
            InitializeComponent();
            cars = new List<Car>();
            carsForms = new List<CarForm>();
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

                cmd.CommandText = @"select * from vehicle inner join model using (idModel) 
                                                inner join brandname using (idBrandName)
                                                where removed=0";

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cars.Add(new Car(reader.GetInt32(3), reader.GetInt32(14), reader.GetInt32(5),
                        reader.GetInt32(6), reader.GetString(8),
                        reader.GetString(7), reader.GetInt32(4), reader.GetString(10), reader.GetInt32(2),
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
                CarForm form = new CarForm(this, car);
                carsForms.Add(form);
                carsStackPanel.Children.Add(form);
            }
        }

        private void LoadTheme()
        {
            var app = (App)Application.Current;

            if (MainWindow.loggedUser.Theme.Equals("default"))
            {
                app.ChangeTheme(new Uri("Styles/DefaultStyle.xaml", UriKind.Relative));
            }
            else if (MainWindow.loggedUser.Theme.Equals("blue"))
            {
                app.ChangeTheme(new Uri("Styles/BlueStyle.xaml", UriKind.Relative));
            }
            else
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

        private void AvailableButtonClick(object sender, RoutedEventArgs e) 
        {
            carsForms.Clear();
            carsStackPanel.Children.Clear();
            LoadCars();
        }

        private void BoughtButtonClick(object sender, RoutedEventArgs e)
        {
            cars.Clear();
            carsForms.Clear();
            carsStackPanel.Children.Clear();


            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = @"select * from buy inner join vehicle using (idVehicle)
                                                inner join model using (idModel)
                                                inner join brandname using (idBrandName)
                                                where buy.idAccount=@id";

                cmd.Parameters.AddWithValue("@id", MainWindow.loggedUser.Id);


                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cars.Add(new Car(reader.GetInt32(4), reader.GetInt32(17), reader.GetInt32(8),
                        reader.GetInt32(9), reader.GetString(11),
                        reader.GetString(10), reader.GetInt32(7), reader.GetString(13), reader.GetInt32(2),
                        reader.GetString(18), reader.GetString(19), reader.GetInt32(14)));
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
                CarForm form = new CarForm(this, car);
                form.Contact.IsEnabled = false;
                form.Buy.IsEnabled = false;
                carsForms.Add(form);
                carsStackPanel.Children.Add(form);
            }
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

            List<Car> searchedCars = new List<Car>(); ;

            if(SearchText.Text.Equals(""))
            {
                LoadCars();
            }
            else
            {
                foreach (Car car in cars)
                {
                    if(String.Equals(car.CarBrand,SearchText.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        searchedCars.Add(car);
                    }
                    else if(String.Equals(car.Model,SearchText.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        searchedCars.Add(car);
                    }    
                }
            }

            foreach(Car car in searchedCars)
            {
                CarForm form = new CarForm(this, car);              
                carsForms.Add(form);
                carsStackPanel.Children.Add(form);
            }

        }

    }
}
