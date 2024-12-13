using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnection sqlConnection;
        public Window1()
        {
            InitializeComponent();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CMPE312_PROJECT;Integrated Security=True;Encrypt=False";
            sqlConnection = new SqlConnection(connectionString);
            LoadComboBox1();
            LoadComboBox2();
        }
        private void LoadComboBox1()
        {
            try
            {
                string query = "SELECT Id, name FROM Passanger";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable passengerTable = new DataTable();
                    sqlDataAdapter.Fill(passengerTable);

                    comboBox1.DisplayMemberPath = "name";
                    comboBox1.SelectedValuePath = "Id";  
                    comboBox1.ItemsSource = passengerTable.DefaultView; 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Bir hata oluştu: {e.Message}");
            }
        }
        private void LoadComboBox2()
        {
            try
            {
                string query = "SELECT Id, plate FROM Bus";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                using (sqlDataAdapter)
                {
                    DataTable busTable= new DataTable();
                    sqlDataAdapter.Fill(busTable);

                    comboBox2.DisplayMemberPath = "plate";
                    comboBox2.SelectedValuePath = "Id";
                    comboBox2.ItemsSource = busTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Bir hata oluştu: {e.Message}");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
