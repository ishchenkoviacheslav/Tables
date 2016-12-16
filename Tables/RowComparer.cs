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
  public static  class RowComparer
    {
        public static int Compare(DataRow x, DataRow y)
        {
            if (x["Id"].ToString()==y["Id"].ToString() && x["FirstName"].ToString()==y["FirstName"].ToString()&&x["LastName"].ToString()==y["LastName"].ToString()&&x["Phone"].ToString()==y["Phone"].ToString()&&x["Email"].ToString()==y["Email"].ToString())
            {
                //в базе данных и у нас строки одинаковые
                return 1;
            }
            else
            {
                //наша строка НЕ одинакова со строкой из БД, тоесть её нужно сохранить
                // проверяем что наша строка имела то же состояние данных на момент её получения, как и в данный момент стока в базе
                //если эта проверка дает false, тоесть в базе другой пользователь данных поменял. Наши данные отбрасываются, тоесть НЕ сохраняются.
                if(x["Id",DataRowVersion.Original].ToString() == y["Id"].ToString() && x["FirstName", DataRowVersion.Original].ToString() == y["FirstName"].ToString() && x["LastName", DataRowVersion.Original].ToString() == y["LastName"].ToString() && x["Phone", DataRowVersion.Original].ToString() == y["Phone"].ToString() && x["Email", DataRowVersion.Original].ToString() == y["Email"].ToString())
                {
                    return 2;
                }
                else
                {
                    //наши данные НЕ сохранять. так как ктото другой уже успел изменить эту строку в базе данных.
                    return 3;

                }
            }
        }
    }
}
