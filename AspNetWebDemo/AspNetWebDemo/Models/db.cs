using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AspNetWebDemo.Models;
using AspNetWebDemo.Tietokanta;

namespace AspNetWebDemo.Models
{
    public class Db
    {
        readonly SqlConnection con = new SqlConnection("Server=LAPTOP-97FTUUUV\\SQLEXPRESS;Database=Varasto; Trusted_Connection=True;");
        public int LoginCheck(LoginDb ad)
        {
            SqlCommand com = new SqlCommand("Sp_login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@admin_id", ad.LoginName);
            com.Parameters.AddWithValue("@Password", ad.LoginPassword);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
    }
}
