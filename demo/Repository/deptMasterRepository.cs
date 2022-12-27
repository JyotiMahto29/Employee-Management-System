using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using demo.Models;



namespace demo.Repository
{
    public class deptRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            con = new SqlConnection(constr);



        }
        //To Add New Department details
        public bool InsertData(deptMaster obj)
        {



            connection();
            int i = 0;
            SqlCommand com = new SqlCommand("sp_insertDepartment", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@deptName", obj.deptName);



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
        //To view department details with generic list 
        public List<deptMaster> GetAllData()
        {
            connection();
            string sqlQuery = "select deptId,deptName from tblDepartment order by deptName";
            List<deptMaster> deptList = new List<deptMaster>();
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
            //Bind deptMaster generic list using LINQ 
            deptList = (from DataRow dr in dt.Rows



                        select new deptMaster()
                        {
                            deptId = Convert.ToInt32(dr["deptId"]),
                            deptName = Convert.ToString(dr["deptName"])

                        }).ToList();




            return deptList;




        }
        //To Update Department details
        public bool UpdateData(deptMaster obj)
        {
            int i = 0;
            connection();
            SqlCommand com = new SqlCommand("sp_UpdateDepartment", con);



            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@deptId", obj.deptId);
            com.Parameters.AddWithValue("@deptName", obj.deptName);



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
        //To delete Department details
        public bool DeleteData(int Id)
        {
            
            int i = 0;
           // string sqlQuery = "delete from tblDepartment where deptId=" + Id;
            connection();
            SqlCommand com = new SqlCommand("sp_deleteDepartment", con);



            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@deptId", Id);



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
    }
}