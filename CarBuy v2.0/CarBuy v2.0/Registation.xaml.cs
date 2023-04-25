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
    /// Interaction logic for Registation.xaml
    /// </summary>
    public partial class Registation : Window
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        public Registation()
        {
            InitializeComponent();
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

        private void SignUpButtonClick(object sender, RoutedEventArgs e)
        {
            List<String> existingUsernames = new List<string>();
            Boolean userExists = false;
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = @"select * from account";

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    existingUsernames.Add(reader.GetString(1));
                }    
                
                
                reader.Close();
                conn.Close();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            foreach(String user in existingUsernames)
            {
                if(user.Equals(username.Text))
                {
                    userExists = true;
                }
            }


            if (username.Text.Equals("") || userExists ||
                firstName.Text.Equals("") || firstName.Text.Any(char.IsDigit) ||
                lastName.Text.Equals("") || lastName.Text.Any(char.IsDigit) ||
                password.Password.ToString().Length < 4 ||
                !IsDigitsOnly(phoneNumber.Text)
                )
            {
                MessageBox.Show("Invalid input!");
            }
            else
            {
                ComboBoxItem role = (ComboBoxItem)roleComboBox.SelectedItem;

                try
                {
                    MySqlConnection conn = new MySqlConnection(connectionString);
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    if (role.Content.ToString().Equals("Buyer"))
                    {
                        cmd.CommandText = @"insert into account (username, password, theme) values (@username, @password, @theme);
                                 insert into person (idAccount, name, lastName, sex, address) values (last_insert_id(), @firstName, @lastName, 1, @address);
                                  insert into buyer (idAccount) values (last_insert_id());
                                  insert into phonenumber (idAccount, phonenumber) values (last_insert_id(), @phoneNumber);";
                    }
                    else
                    {
                        cmd.CommandText = @"insert into account (username, password, theme) values (@username, @password, @theme);
                                 insert into person (idAccount, name, lastName, sex, address) values (last_insert_id(), @firstName, @lastName, 1, @address);
                                  insert into salesbody (idAccount) values (last_insert_id());
                                  insert into salesman (idAccount) values (last_insert_id());
                                  insert into phonenumber (idAccount, phoneNumber) values (last_insert_id(), @phoneNumber);";
                    }
                    cmd.Parameters.AddWithValue("@username", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Password.ToString());
                    cmd.Parameters.AddWithValue("@theme", "default");
                    cmd.Parameters.AddWithValue("@firstName", firstName.Text);
                    cmd.Parameters.AddWithValue("@lastName", lastName.Text);
                    cmd.Parameters.AddWithValue("@address", "bb");
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber.Text);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    reader.Close();
                    conn.Close();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }

                MainWindow mainWindow = new MainWindow();
                this.Hide();
                mainWindow.Show();
            }

        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Hide();
            main.Show();
        }
    }
}
