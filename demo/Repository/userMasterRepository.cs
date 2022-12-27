using demo.Common;
using demo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace demo.Repository
{
    public class userMasterRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        Password encryptPassword = new Password();
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            con = new SqlConnection(constr);

        }
        public bool InsertData(userMaster obj)
        {
            connection();
            int i = 0;
            SqlCommand com = new SqlCommand("proc_RegisterUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@userName", obj.userName);
            com.Parameters.AddWithValue("@userEmail", obj.userEmail);
            com.Parameters.AddWithValue("@userPassword",encryptPassword.EncryptPassword (obj.userPassword));

            try
            {
                con.Open();
                i = com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception exp)
            {
                con.Close();
                com.Dispose();
                Console.WriteLine(exp.Message);
            }
            finally
            {
                con.Close();
                com.Dispose();
                con.Dispose();
            }
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

        public userMaster Authentication(userLogin log)
        {
            connection();
            string sqlQuery = "select * from tblUser where userEmail='"+log.userEmail+"' and userPassword='"+ encryptPassword.EncryptPassword(log.userPassword) + "'";
            userMaster userlogin =new userMaster();
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            catch (Exception exp)
            {
                con.Close();
                com.Dispose();
                Console.WriteLine(exp.Message);
            }
            finally
            {
                con.Close();
                com.Dispose();
                con.Dispose();
            }
            if (dt.Rows.Count > 0)
            {
                userlogin.userName = dt.Rows[0]["userName"].ToString();
                userlogin.userId = Convert.ToInt32(dt.Rows[0]["userId"]);
            }
            else
            {
                userlogin = null;   
            }



            return userlogin;




        }
    }
}