using System;
using System.Data;
using System.Data.SqlClient;


namespace data_layer
{
    internal class CD_Connection
    {
        private readonly SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS; Initial Catalog=Store; Integrated Security=True;");

        public SqlConnection OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        public SqlConnection ClouseConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            return con;
        }
    }
}


