using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace Tables
{
    public partial class MainForm : Form
    {
        public List<Client> ClientList = new List<Client>();
        public MainForm()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();
                string com = "Select * From Contact";
                SqlCommand SqlCom = new SqlCommand(com, con);
                using (SqlDataReader reader = SqlCom.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClientList.Add(new Client() { FirstName = reader["FirstName"].ToString(), LastName = reader["LastName"].ToString(), Phone = reader["Phone"].ToString(), Email = reader["Email"].ToString(), Id = int.Parse(reader["Id"].ToString()) });
                    }
                }
            }
            ContactView.DataSource = ClientList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contact_Click(object sender, EventArgs e)
        {
            ClientList.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = connectionString;
                con.Open();
                string com = "Select * From Contact";
                SqlCommand SqlCom = new SqlCommand(com, con);
                using (SqlDataReader reader = SqlCom.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClientList.Add(new Client() { FirstName = reader["FirstName"].ToString(), LastName = reader["LastName"].ToString(), Phone = reader["Phone"].ToString(), Email = reader["Email"].ToString(), Id = int.Parse(reader["Id"].ToString()) });
                    }
                }
            }
            ContactView.DataSource = null;
            ContactView.DataSource = ClientList;
        }
    }
}
