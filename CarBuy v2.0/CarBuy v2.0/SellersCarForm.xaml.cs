using CarBuy_v2._0.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
using Path = System.IO.Path;

namespace CarBuy_v2._0
{
    /// <summary>
    /// Interaction logic for SellersCarForm.xaml
    /// </summary>
    public partial class SellersCarForm : UserControl
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        public Car Car { get; set; }
        public SellersWindow SellersWindow { get; set; }

        public SellersCarForm(SellersWindow sellersWindow, Car car)
        {
            InitializeComponent();
            LoadTheme();
            SellersWindow = sellersWindow;
            Car = car;
            basicInfo.Content = car.CarBrand + " " + car.Model;
            makeYear.Content = car.MakeYear;
            mileage.Content = car.Milage;
            hp.Content = car.HorsePower;
            doors.Content = car.Doors;
            fuelType.Content = car.FuelType;
            transmision.Content = car.Transmision;
            type.Content = car.CarType;
            registration.Content = car.Registration;

            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            if(Car.Model.Equals("A4"))
            {
                string fileName = @"audia4.jpg";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                bitmap.UriSource = new Uri(path);
            }
            else if(Car.Model.Equals("A5"))
            {
                string fileName = @"audia5.jpg";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                bitmap.UriSource = new Uri(path);
            }
            else if (Car.Model.Equals("A6"))
            {
                string fileName = @"audia6.jpg";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                bitmap.UriSource = new Uri(path);
            }
            else if (Car.Model.Equals("F10"))
            {
                string fileName = @"bmwf10.jpg";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                bitmap.UriSource = new Uri(path);
            }
            else if (Car.Model.Equals("F30"))
            {
                string fileName = @"bmwf30.jpg";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                bitmap.UriSource = new Uri(path);
            }
            else if (Car.Model.Equals("A Klasa"))
            {
                string fileName = @"mercedesaclass.jpg";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                bitmap.UriSource = new Uri(path);
            }
            else if (Car.Model.Equals("C Klasa"))
            {
                string fileName = @"mercedescclass.jpg";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                bitmap.UriSource = new Uri(path);
            }
            else if (Car.Model.Equals("E Klasa"))
            {
                string fileName = @"mercedeseclass.jpg";
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                bitmap.UriSource = new Uri(path);
            }

            bitmap.DecodePixelWidth = 290;
            bitmap.EndInit();

            carImage.Source = bitmap; 
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
            else if (MainWindow.loggedUser.Theme.Equals("default") && MainWindow.language.Equals("Serbian"))
            {
                app.ChangeTheme(new Uri("Styles/DefaultStyleSerbian.xaml", UriKind.Relative));
            }
            else if (MainWindow.loggedUser.Theme.Equals("blue") && MainWindow.language.Equals("Serbian"))
            {
                app.ChangeTheme(new Uri("Styles/BlueStyleSerbian.xaml", UriKind.Relative));
            }
            else if (MainWindow.loggedUser.Theme.Equals("red") && MainWindow.language.Equals("Serbian"))
            {
                app.ChangeTheme(new Uri("Styles/RedStyleSerbian.xaml", UriKind.Relative));
            }
        }

        private void RemoveButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = @"UPDATE vehicle SET removed=1 where (idVehicle=@id)";
                cmd.Parameters.AddWithValue("@id", Car.Id);

                MySqlDataReader reader = cmd.ExecuteReader();

                
                reader.Close();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
