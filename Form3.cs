using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_REX_10._5
{
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Abdur Rafay\\source\\repos\\T-REX 10.5\\Database1.mdf\";Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
            LoadScores();
        }
        private void LoadScores()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT PlayerName, Score FROM [Scores]";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["PlayerName"].HeaderText = "Player Name";
                dataGridView1.Columns["Score"].HeaderText = "Score";
            }
        }
    }
}
