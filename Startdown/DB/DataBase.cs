using System.Data.SqlClient;

namespace Startdown.DB
{
    public class DataBase
    {



        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UIR8C5V;Initial Catalog=StartDown_DB;Integrated Security=True");
        public DataBase()
        {
            conn.Open();
        }
        public void CloseConn()
        {
            if(conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        int prom()
        {
            return 0;
        }
    }
}
