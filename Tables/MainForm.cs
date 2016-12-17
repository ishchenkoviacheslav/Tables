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
        TableAdapter tableAdapt = null;
        DataTable myTable = null;
        public MainForm()
        {
            InitializeComponent();
            //в этом собитии закрытия при исключительной ситуации происходит отмета закрытия.
            this.FormClosing += MainForm_FormClosing;
            tableAdapt = new TableAdapter(ConfigurationManager.ConnectionStrings["myConnString"].ConnectionString);
            myTable = tableAdapt.GetAllContact();
            ContactView.DataSource = myTable;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveAndChek();
            }
            catch (Exception)
            {
                e.Cancel = true;
                MessageBox.Show("Некоторые(или все) данные не были сохранены...Закрытие программы было отменено");
            }
        }

        private void contact_Click(object sender, EventArgs e)
        {
            try
            {
                SaveAndChek();
            }
            catch (Exception)
            {
               
            }
        }

        private void SaveAndChek()
        {
            string RowWithoutSave = string.Empty;
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
                        RowWithoutSave += ((changedDT.Rows[i])["Id"]);
                        changedDT.Rows[i].RejectChanges();
                        break;
                }

            }

            // Зафиксировать изменения.
            tableAdapt.UpdateContact(changedDT);
            if (RowWithoutSave != string.Empty)
            {
                MessageBox.Show(string.Format("Строка с Id: {0} сохранена не была. \n", RowWithoutSave));
                throw new Exception();
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            ContactView.DataSource = tableAdapt.GetAllContact();
        }
    }
}
