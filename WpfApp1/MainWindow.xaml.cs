using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CMPE312_PROJECT;Integrated Security=True;Encrypt=False";
            sqlConnection = new SqlConnection(connectionString);
            ShowBusList();
            ShowDriverList();
            ShowPassengerList();
        }
        private void ShowBusList()
        {
            try
            {
                string query = "select * from Bus";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable busTable = new DataTable();
                    sqlDataAdapter.Fill(busTable);
                    buslist.DisplayMemberPath = "plate";
                    buslist.SelectedValuePath = "Id";
                    buslist.ItemsSource = busTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ShowDriverList()
        {
            try
            {
                string query = "select * from Driver";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable driverTable = new DataTable();
                    sqlDataAdapter.Fill(driverTable);
                    driverlist.DisplayMemberPath = "name";
                    driverlist.SelectedValuePath = "Id";
                    driverlist.ItemsSource = driverTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void ShowPassengerList()
        {
            try
            {
                string query = "select * from Passanger";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable passengerTable = new DataTable();
                    sqlDataAdapter.Fill(passengerTable);
                    passengerlist.DisplayMemberPath = "name";
                    passengerlist.SelectedValuePath = "Id";
                    passengerlist.ItemsSource = passengerTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void assignButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
        }
    }
}
