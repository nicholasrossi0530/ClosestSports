using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ClosestSports
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int NUM_SPORTS = 4;
        public MainWindow()
        {
            List<String> sports = new List<string>();
            sports.Add("hockey");
            //Model m = new Model(sports, "84041", 50, "mile");
            //m.getSurroundingZipCodesBasedOnRadiusAsync();
            //Console.WriteLine(m.ToString());

            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
            /*
            List<String> sports = new List<string>();
            foreach (ListBoxItem item in listBoxSports.Items)
            {
                if (item.IsSelected)
                {
                    sports.Add(item.Content.ToString());
                }
            }
            String zipCode = textBoxZipCode.Text;
            int radius = Int32.Parse(textBoxRadius.Text);
            String radiusUnits = ((ListBoxItem)(listBoxRadiusUnits.SelectedItem)).Content.ToString();
            Model m = new Model(sports, zipCode, radius, radiusUnits);
            Console.WriteLine(m.ToString());
             */


            string queryString = "SELECT *  FROM  Team";
            string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=ClosestSportsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}",
                        reader["TeamId"], reader["TeamName"]));
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }


        }
    }
}
