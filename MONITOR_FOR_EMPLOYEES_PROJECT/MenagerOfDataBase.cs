using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
//using System.Configuration.ConfigurationManager;

namespace MONITOR_FOR_EMPLOYEES_PROJECT
{
    class MenagerOfDataBase
    {
        SqlConnection connection;
        string myConnectionString;

        MenagerOfDataBase()
        {
            myConnectionString = ConfigurationManager.ConnectionStrings["DataBase.Properties.Settings.DataBaseConnectionString"].ConnectionString;
        }

        public void addDataToTable(string nameOfTable,params object[] values)
        {
            using (connection = new SqlConnection(myConnectionString))
            {

            }
           
        }
    }
}
