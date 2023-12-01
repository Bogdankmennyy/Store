using System.Data.SqlClient;
using System.Data;
using coat_Entity;
using data_layer;

namespace coat_data_layer
{
    public class CD_Users
    {
        private readonly CD_Connection con=new CD_Connection();
        private readonly CE_Users ce = new CE_Users();



        public void CD_Insentar(CE_Users Users)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.OpenConnection(),
                CommandText = "SP_U_Insert",
                CommandType = CommandType.StoredProcedure,
            };
            com.Parameters.AddWithValue("@Names", Users.Names);
            com.Parameters.AddWithValue("@Surnames", Users.Surnames);
            com.Parameters.AddWithValue("@DUI", Users.DUI);
            com.Parameters.AddWithValue("@NIT", Users.NIT);
            com.Parameters.AddWithValue("@Mail", Users.Mail);
            com.Parameters.AddWithValue("@Phone", Users.Phone);
            com.Parameters.Add("@Birthday", SqlDbType.Date).Value=Users.Birthday;
            com.Parameters.AddWithValue("@Privilege", Users.Privilege);
            com.Parameters.AddWithValue("@img", Users.Img);
            com.Parameters.AddWithValue("@userr", Users.Userr);
            com.Parameters.AddWithValue("@passwordd", Users.Passwordd);
            com.Parameters.AddWithValue("@patron", Users.Patron);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.ClouseConnection();
        }



        public CE_Users Consult(int IdUser)
        {
            SqlDataAdapter da = new SqlDataAdapter("SP_U_Consult", con.OpenConnection());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdUser", SqlDbType.Int).Value = IdUser;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt;
            dt = ds.Tables[0];
            DataRow row = dt.Rows[0];
            
            ce.Names = Convert.ToString(row[1]);
            ce.Surnames = Convert.ToString(row[2]);
            ce.DUI = Convert.ToInt32(row[3]);
            ce.NIT = Convert.ToInt32(row[4]);
            ce.Mail = Convert.ToString(row[5]);
            ce.Phone = Convert.ToInt32(row[6]);
            ce.Birthday = Convert.ToDateTime(row[7]);
            ce.Privilege = Convert.ToInt32(row[8]);
            ce.Img = (byte[])row[9];
            ce.Userr = Convert.ToString(row[10]);

            return ce;

        }

        public void CD_Remove(CE_Users Users)
        {
            SqlCommand com = new SqlCommand()
            {
            Connection = con.OpenConnection(),
            CommandText = "SP_U_Remove",
            CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@IdUser", Users.IdUser);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.ClouseConnection();
        
        
        }


        public void CD_UpdateData(CE_Users Users)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.OpenConnection(),
                CommandText = "SP_U_UpdateData",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@Names", Users.Names);
            com.Parameters.AddWithValue("@Surnames", Users.Surnames);
            com.Parameters.AddWithValue("@DUI", Users.DUI);
            com.Parameters.AddWithValue("@NIT", Users.NIT);
            com.Parameters.AddWithValue("@Mail", Users.Mail);
            com.Parameters.AddWithValue("@Phone", Users.Phone);
            com.Parameters.Add("@Birthday", SqlDbType.Date).Value = Users.Birthday;
            com.Parameters.AddWithValue("@Privilege", Users.Privilege);
            com.Parameters.AddWithValue("@userr", Users.Userr);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.ClouseConnection();

        }


        public void CD_UpdatePass(CE_Users Users)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.OpenConnection(),
                CommandText = "SP_U_UpdatePass",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@IdUser", Users.IdUser);
            com.Parameters.AddWithValue("@passwordd", Users.Passwordd);
            com.Parameters.AddWithValue("@patron", Users.Patron);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.ClouseConnection();
        }

        public void CD_UpdateIMG(CE_Users Users)
        {
            SqlCommand com = new SqlCommand()
            {
                Connection = con.OpenConnection(),
                CommandText = "SP_U_UpdateIMG",
                CommandType = CommandType.StoredProcedure
            };
            com.Parameters.AddWithValue("@IdUser", Users.IdUser);
            com.Parameters.AddWithValue("@img", Users.Img);
            com.ExecuteNonQuery();
            com.Parameters.Clear();
            con.ClouseConnection();
        }


    }
}
