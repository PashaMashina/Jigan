using System;
using System.Data;
using System.Data.SqlClient;

namespace DBClient
{
    public class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=C:\USERS\EVTUH\ONEDRIVE\РАБОЧИЙ СТОЛ\DRIVERRACES.MDF;Integrated Security=True");
        
        private static String path = @"C:\Users\evtuh\OneDrive\Рабочий стол\DriverRaces.mdf";

        //SqlConnection sqlConnection = new(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True;Connect Timeout=30");
        
        //public SqlConnection GetSqlConnection()
        //{
        //    SqlConnection connection = new();
        //    SqlConnectionStringBuilder sb = new();
        //    sb.DataSource = @"(LocalDB)\MSSQLLocalDB";
        //    sb.AttachDBFilename = @"C:\Users\evtuh\OneDrive\Рабочий стол\DriverRaces.mdf";
        //    sb.IntegratedSecurity = true;
        //    sb.ConnectTimeout = 30;

        //    connection.ConnectionString = sb.ToString();

        //    return connection;
        //}
        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }
        public void openConnection()
        {
            //SqlConnection connection = GetSqlConnection();
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            //SqlConnection connection = GetSqlConnection();
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
    }
}
