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
        //public List<Client> ClientList = new List<Client>();
        TableAdapter tableAdapt = null;
        DataTable myTable = null; 
        public MainForm()
        {
            InitializeComponent();
            tableAdapt = new TableAdapter(ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString);
            myTable = tableAdapt.GetAllContact();
            ContactView.DataSource = myTable;
          
            foreach (DataRow row in myTable.Rows)
            {
                myTxtBox.Text += (row.RowState.ToString());
            }
            //using (SqlConnection con = new SqlConnection())
            //{
            //    con.ConnectionString = connectionString;
            //    con.Open();
            //    string com = "Select * From Contact";
            //    SqlCommand SqlCom = new SqlCommand(com, con);
            //    using (SqlDataReader reader = SqlCom.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            ClientList.Add(new Client() { FirstName = reader["FirstName"].ToString(), LastName = reader["LastName"].ToString(), Phone = reader["Phone"].ToString(), Email = reader["Email"].ToString(), Id = int.Parse(reader["Id"].ToString()) });
            //        }
            //    }
            //}
            //ContactView.DataSource = ClientList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contact_Click(object sender, EventArgs e)
        {
            //наша измененная версия
            DataTable changedDT = (DataTable)ContactView.DataSource;
            //свежая текущая версия из базы данных, нужна для сравнения
            DataTable freshTableFromDB = tableAdapt.GetAllContact();
            for (int i = 0; i < freshTableFromDB.Rows.Count; i++)
            {
                //найти происходили ли изменения в базе данных с момента нашего последнего получения данных.
                switch (RowComparer.Compare(changedDT.Rows[i], freshTableFromDB.Rows[i]))
                {
                    //в стоке ничего не менялось
                    case 1:
                        
                        break;
                    
                    case 2:

                        break;
                    //строка была изменена НО другой пользователь уже успел внести изменения
                    //в ту же строку поэтому наши данные по этой стоке не сохраняются
                    case 3:
                        changedDT.Rows[i].RejectChanges();
                        break;
                }
                
            }
            try
            {
                // Зафиксировать изменения.
                tableAdapt.UpdateContact(changedDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //ClientList.Clear();
            //string connectionString = ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString;
            //using (SqlConnection con = new SqlConnection())
            //{
            //    con.ConnectionString = connectionString;
            //    con.Open();
            //    string com = "Select * From Contact";
            //    SqlCommand SqlCom = new SqlCommand(com, con);
            //    using (SqlDataReader reader = SqlCom.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            ClientList.Add(new Client() { FirstName = reader["FirstName"].ToString(), LastName = reader["LastName"].ToString(), Phone = reader["Phone"].ToString(), Email = reader["Email"].ToString(), Id = int.Parse(reader["Id"].ToString()) });
            //        }
            //    }
            //}
            //ContactView.DataSource = null;
            //ContactView.DataSource = ClientList;
        }

        private void infoAfterChange_Click(object sender, EventArgs e)
        {
            myTxtBox.Text = string.Empty;
            foreach (DataRow row in myTable.Rows)
            {
                myTxtBox.Text += (row.RowState.ToString());
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            ContactView.DataSource = tableAdapt.GetAllContact();
        }
    }
}
