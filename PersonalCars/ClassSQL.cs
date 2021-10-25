using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalCars
{
    public class ClassSQL
    {
        public static string connectionStr = @"Data Source=MSI\SQLEXPRESSS;Initial Catalog=10180023;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static bool IsResult(string sqlExpression)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand sql = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = sql.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                return true;
            }
            else return false;
        }

        public static string Count(string sqlExpression)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand sql = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = sql.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                return reader[0].ToString();
            }
            else
                return null;
        }
    }
}
