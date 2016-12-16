using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Tables
{
    public class TableAdapter
    {
        private string cnString = string.Empty;
        private SqlDataAdapter dAdapt = null;
        public TableAdapter(string connectionString)
        {
            cnString = connectionString;
            ConfigureAdapter(out dAdapt);

        }
        private void ConfigureAdapter(out SqlDataAdapter dAdapt)
        {
            // Создать адаптер и настроить SelectCommand.
            dAdapt = new SqlDataAdapter("Select * From Contact", cnString);
            // Динамически получить остальные объекты команд
            // во время выполнения, используя SqlCommandBuilder.
            SqlCommandBuilder builder = new SqlCommandBuilder(dAdapt);
        }

        public DataTable GetAllContact()
        {
            DataTable inv = new DataTable("Contact");
            dAdapt.Fill(inv);
            return inv;
        }

        public void UpdateContact(DataTable modifiedTable)
        {
            dAdapt.Update(modifiedTable);
        }

    }
}
