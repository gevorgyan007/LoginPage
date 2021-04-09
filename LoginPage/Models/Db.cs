using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using LoginPage.Models;

namespace LoginPage.Models
{
    public class Db
    {
        SqlConnection con = new SqlConnection("Data Source=TARONGEV;Initial Catalog=UserPas;Integrated Security=True");

        public int LoginCheck(Login log)
        {
            SqlCommand com = new SqlCommand("sp_Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName",log.UserName);
            com.Parameters.AddWithValue("@UserPassword", log.UserPassword);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@valid";
            param.SqlDbType = SqlDbType.Bit;
            param.Direction = ParameterDirection.Output;
            com.Parameters.Add(param);
            con.Open();
            com.ExecuteNonQuery();
            int result = Convert.ToInt32(param.Value);
            con.Close();
            return result;
        }
    }
}
