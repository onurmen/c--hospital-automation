using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Proje_Hastane
{
    class DatabaseConnection
    {
        public SqlConnection Connnection()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-J82AN47;Initial Catalog=HastaneProje;Integrated Security=True");
            con.Open();
            return con;
       }      

    }
}
