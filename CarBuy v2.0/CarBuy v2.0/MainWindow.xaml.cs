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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarBuy_v2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public static Account? loggedUser;
        public static string language="English";
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

        public MainWindow()
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
        private void signUpButtonClick(object sender, RoutedEventArgs e)
        {
            Registation registation = new Registation();
            this.Hide();
            registation.Show();
        }

        private void buttonLogin_Click_1(object sender, RoutedEventArgs e)
        {
            string name =username.Text;
            string pass =password.Password.ToString();

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = @"select * from account inner join buyer using (idAccount) where username=@username and password=@password";

                cmd.Parameters.AddWithValue("@username", name);
                cmd.Parameters.AddWithValue("@password", pass);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    if (reader.GetString(1).Equals(username.Text) && reader.GetString(2).Equals(password.Password.ToString()))
                    {
                        loggedUser = new Account(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                        BuyersWindow buyersWindow = new BuyersWindow();
                        this.Hide();
                        buyersWindow.Show();
                        reader.Close();
                        conn.Close();
                        return;
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                    }
                }
               



                MySqlConnection conn1 = new MySqlConnection(connectionString);
                conn1.Open();
                MySqlCommand cmd1 = conn1.CreateCommand();
               
                cmd1.CommandText = @"select * from account inner join salesman using (idAccount) where username=@username and password=@password";
                cmd1.Parameters.AddWithValue("@username", name);
                cmd1.Parameters.AddWithValue("@password", pass);
               
                MySqlDataReader mreader = cmd1.ExecuteReader();

                while (mreader.Read())
                {

                    if (mreader.GetString(1).Equals(username.Text) && mreader.GetString(2).Equals(password.Password.ToString()))
                    {
                        loggedUser = new Account(mreader.GetInt32(0), mreader.GetString(1), mreader.GetString(2), mreader.GetString(3));
                        SellersWindow sellersWindow = new SellersWindow();
                        this.Hide();
                        sellersWindow.Show();
                        mreader.Close();
                        conn.Close();
                        return;
                    }
                    else
                    {
                        mreader.Close();
                        conn.Close();
                    }
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            MessageBox.Show("Invalid username or password!");

        }
    }
}
