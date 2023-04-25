using CarBuy_v2._0.Models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
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
using System.Windows.Shapes;

namespace CarBuy_v2._0
{
    /// <summary>
    /// Interaction logic for AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        public AddCar()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private int getVehicleType(string type)
        {
            if (type.Equals("Sedan"))
            {
                return 1;
            }
            else if (type.Equals("Wagon"))
            {
                return 2;
            }
            else if (type.Equals("Hatchback"))
            {
                return 3;
            }
            else if (type.Equals("Cabrio"))
            {
                return 4;
            }
            else
            {
                throw new Exception();
            }
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            ComboBoxItem brand = (ComboBoxItem)CarBrand.SelectedItem;

            if (brand.Content.ToString().Equals("Mercedes"))
            {
                if (Model.Text.ToLower().Equals("a class") || Model.Text.ToLower().Equals("c class"))
                {

                    if (int.TryParse(Mileage.Text, out _) && int.TryParse(HorsePower.Text, out _) && int.TryParse(MakeYear.Text, out _))
                    {

                        try
                        {
                            MySqlConnection conn = new MySqlConnection(connectionString);
                            conn.Open();
                            MySqlCommand cmd = conn.CreateCommand();

                            cmd.CommandText = @"insert into vehicle(idAccount, idVehicleType, idModel, horsePower, numberOfDoors, transmission, 
                                                fuel, seatNumber, registrationNumber, makeYear, vehicle.load, removed, milage) 
                                                values(@idAccount, @idVehicleType, @idModel, @horsePower, @numberOfDoors, @transmission, 
                                                @fuel, @seatNumber, @registrationNumber, @makeYear, @load, @removed, @milage); ";

                            cmd.Parameters.AddWithValue("@idAccount", MainWindow.loggedUser.Id);
                            ComboBoxItem type = (ComboBoxItem)Type.SelectedItem;
                            cmd.Parameters.AddWithValue("@idVehicleType", getVehicleType(type.Content.ToString()));
                            if (Model.Text.ToLower().Equals("a class"))
                            {
                                cmd.Parameters.AddWithValue("@idModel", 8);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@idModel", 6);
                            }
                            int hp;
                            int.TryParse(HorsePower.Text, out hp);
                            cmd.Parameters.AddWithValue("@horsePower", hp);
                            ComboBoxItem doors = (ComboBoxItem)Doors.SelectedItem;
                            int doors1;
                            int.TryParse(doors.Content.ToString(), out doors1);
                            cmd.Parameters.AddWithValue("@numberOfDoors", doors1);
                            ComboBoxItem trans = (ComboBoxItem)Transmision.SelectedItem;
                            cmd.Parameters.AddWithValue("@transmission", trans.Content.ToString());
                            ComboBoxItem fuel = (ComboBoxItem)Fuel.SelectedItem;
                            cmd.Parameters.AddWithValue("@fuel", fuel.Content.ToString());
                            ComboBoxItem seats = (ComboBoxItem)Seats.SelectedItem;
                            cmd.Parameters.AddWithValue("@seatNumber", seats.Content.ToString());
                            cmd.Parameters.AddWithValue("@registrationNumber", Registration.Text);
                            int year;
                            int.TryParse(MakeYear.Text, out year);
                            cmd.Parameters.AddWithValue("@makeYear", year);
                            cmd.Parameters.AddWithValue("@load", 0);
                            cmd.Parameters.AddWithValue("@removed", 0);
                            int mileage;
                            int.TryParse(Mileage.Text, out mileage);
                            cmd.Parameters.AddWithValue("@milage", mileage);

                            MySqlDataReader reader = cmd.ExecuteReader();
                            reader.Close();
                            conn.Close();
                            this.Close();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.StackTrace);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong input!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong input!");
                }

            }
            else if (brand.Content.ToString().Equals("Audi"))
            {
                if (Model.Text.ToLower().Equals("a4") || Model.Text.ToLower().Equals("a5") || Model.Text.ToLower().Equals("a6"))
                {
                    if (int.TryParse(Mileage.Text, out _) && int.TryParse(HorsePower.Text, out _) && int.TryParse(MakeYear.Text, out _))
                    {
                        try
                        {
                            MySqlConnection conn = new MySqlConnection(connectionString);
                            conn.Open();
                            MySqlCommand cmd = conn.CreateCommand();

                            cmd.CommandText = @"insert into vehicle(idAccount, idVehicleType, idModel, horsePower, numberOfDoors, transmission, 
                                                fuel, seatNumber, registrationNumber, makeYear, vehicle.load, removed, milage) 
                                                values(@idAccount, @idVehicleType, @idModel, @horsePower, @numberOfDoors, @transmission, 
                                                @fuel, @seatNumber, @registrationNumber, @makeYear, @load, @removed, @milage); ";

                            cmd.Parameters.AddWithValue("@idAccount", MainWindow.loggedUser.Id);
                            ComboBoxItem type = (ComboBoxItem)Type.SelectedItem;
                            cmd.Parameters.AddWithValue("@idVehicleType", getVehicleType(type.Content.ToString()));
                            if (Model.Text.ToLower().Equals("a4"))
                            {
                                cmd.Parameters.AddWithValue("@idModel", 1);
                            }
                            else if (Model.Text.ToLower().Equals("a5"))
                            {
                                cmd.Parameters.AddWithValue("@idModel", 2);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@idModel", 3);
                            }
                            int hp;
                            int.TryParse(HorsePower.Text, out hp);
                            cmd.Parameters.AddWithValue("@horsePower", hp);
                            ComboBoxItem doors = (ComboBoxItem)Doors.SelectedItem;
                            int doors1;
                            int.TryParse(doors.Content.ToString(), out doors1);
                            cmd.Parameters.AddWithValue("@numberOfDoors", doors1);
                            ComboBoxItem trans = (ComboBoxItem)Transmision.SelectedItem;
                            cmd.Parameters.AddWithValue("@transmission", trans.Content.ToString());
                            ComboBoxItem fuel = (ComboBoxItem)Fuel.SelectedItem;
                            cmd.Parameters.AddWithValue("@fuel", fuel.Content.ToString());
                            ComboBoxItem seats = (ComboBoxItem)Seats.SelectedItem;
                            cmd.Parameters.AddWithValue("@seatNumber", seats.Content.ToString());
                            cmd.Parameters.AddWithValue("@registrationNumber", Registration.Text);
                            int makeYear;
                            int.TryParse(MakeYear.Text, out makeYear);
                            cmd.Parameters.AddWithValue("@makeYear", makeYear);
                            cmd.Parameters.AddWithValue("@load", 0);
                            cmd.Parameters.AddWithValue("@removed", 0);
                            int mileage;
                            int.TryParse(Mileage.Text, out mileage); 
                            cmd.Parameters.AddWithValue("@milage", mileage);

                            MySqlDataReader reader = cmd.ExecuteReader();
                            reader.Close();
                            conn.Close();
                            this.Close();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.StackTrace);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong input!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong input!");
                }

            }
            else if (brand.Content.ToString().Equals("BMW"))
            {
                if (Model.Text.ToLower().Equals("f10") || Model.Text.ToLower().Equals("f30"))
                {
                    if (int.TryParse(Mileage.Text, out _) && int.TryParse(HorsePower.Text, out _) && int.TryParse(MakeYear.Text, out _))
                    {
                        try
                        {
                            MySqlConnection conn = new MySqlConnection(connectionString);
                            conn.Open();
                            MySqlCommand cmd = conn.CreateCommand();

                            cmd.CommandText = @"insert into vehicle(idAccount, idVehicleType, idModel, horsePower, numberOfDoors, transmission, 
                                                fuel, seatNumber, registrationNumber, makeYear, vehicle.load, removed, milage) 
                                                values(@idAccount, @idVehicleType, @idModel, @horsePower, @numberOfDoors, @transmission, 
                                                @fuel, @seatNumber, @registrationNumber, @makeYear, @load, @removed, @milage); ";

                            cmd.Parameters.AddWithValue("@idAccount", MainWindow.loggedUser.Id);
                            ComboBoxItem type = (ComboBoxItem)Type.SelectedItem;
                            cmd.Parameters.AddWithValue("@idVehicleType", getVehicleType(type.Content.ToString()));
                            if (Model.Text.ToLower().Equals("f10"))
                            {
                                cmd.Parameters.AddWithValue("@idModel", 5);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@idModel", 4);
                            }
                            int hp;
                            int.TryParse(HorsePower.Text, out hp);
                            cmd.Parameters.AddWithValue("@horsePower", hp);
                            ComboBoxItem doors = (ComboBoxItem)Doors.SelectedItem;
                            int doors1;
                            int.TryParse(doors.Content.ToString(), out hp);
                            cmd.Parameters.AddWithValue("@numberOfDoors", hp);
                            ComboBoxItem trans = (ComboBoxItem)Transmision.SelectedItem;
                            cmd.Parameters.AddWithValue("@transmission", trans.Content.ToString());
                            ComboBoxItem fuel = (ComboBoxItem)Fuel.SelectedItem;
                            cmd.Parameters.AddWithValue("@fuel", fuel.Content.ToString());
                            ComboBoxItem seats = (ComboBoxItem)Seats.SelectedItem;
                            cmd.Parameters.AddWithValue("@seatNumber", seats.Content.ToString());
                            cmd.Parameters.AddWithValue("@registrationNumber", Registration.Text);
                            int makeYear;
                            int.TryParse(MakeYear.Text, out makeYear);
                            cmd.Parameters.AddWithValue("@makeYear", makeYear);
                            cmd.Parameters.AddWithValue("@load", 0);
                            cmd.Parameters.AddWithValue("@removed", 0);
                            int mileage;
                            int.TryParse(Mileage.Text, out mileage);
                            cmd.Parameters.AddWithValue("@milage", mileage);

                            MySqlDataReader reader = cmd.ExecuteReader();
                            reader.Close();
                            conn.Close();
                            this.Close();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.StackTrace);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong input!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong input!");
                }

            }

            
        }
    }
}
