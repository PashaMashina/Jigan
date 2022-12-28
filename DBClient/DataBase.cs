using System;
using System.Data;
using System.Data.SqlClient;

namespace DBClient
{
    public class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=BackUp;Integrated Security=True");
        
        //private static String path = @"C:\Users\evtuh\OneDrive\Рабочий стол\DriverRaces.mdf";

        //SqlConnection sqlConnection = new(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True;Connect Timeout=30");

        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }
        public void openConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }
}
