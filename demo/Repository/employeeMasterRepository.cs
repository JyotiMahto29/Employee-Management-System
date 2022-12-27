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
    public class employeeMasterRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            con = new SqlConnection(constr);
        }
        //To Add New Employee details
        public bool InsertData(employeeMaster obj)
        {
            connection();
            int i = 0;
            SqlCommand com = new SqlCommand("sp_insertEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeName", obj.EmployeeName);
            com.Parameters.AddWithValue("@Position", obj.Position);
            com.Parameters.AddWithValue("@Salary", obj.Salary);
            com.Parameters.AddWithValue("@Contact", obj.Contact);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@EmailId", obj.EmailId);
            com.Parameters.AddWithValue("@deptId", obj.deptId);

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
        //To view Employee details with generic list 
        public List<employeeMaster> GetAllData()
        {
            connection();
            string sqlQuery = "select * from Employee";

            List<employeeMaster> empList = new List<employeeMaster>();
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
            //Bind employeeMaster generic list using LINQ 
            empList = (from DataRow dr in dt.Rows
                        select new employeeMaster()
                        {
                            EmployeeId = Convert.ToInt32(dr["EmployeeId"]),
                            EmployeeName = Convert.ToString(dr["EmployeeName"]),
                            Position = Convert.ToString(dr["Position"]),
                            Salary = Convert.ToInt32(dr["Salary"]),
                            Contact = Convert.ToString(dr["Contact"]),
                            Address = Convert.ToString(dr["Address"]),
                            EmailId = Convert.ToString(dr["EmailId"]),
                            deptId = Convert.ToInt32(dr["deptId"]),

                        }).ToList();




            return empList;




        }
        //To Update Employee details
        public bool UpdateData(employeeMaster obj)
        {
            int i = 0;
            connection();
            SqlCommand com = new SqlCommand("sp_UpdateEmployee", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
            com.Parameters.AddWithValue("@EmployeeName", obj.EmployeeName);
            com.Parameters.AddWithValue("@Position", obj.Position);
            com.Parameters.AddWithValue("@Salary", obj.Salary);
            com.Parameters.AddWithValue("@Contact", obj.Contact);
            com.Parameters.AddWithValue("@Address", obj.Address);
            com.Parameters.AddWithValue("@EmailId", obj.EmailId);
            com.Parameters.AddWithValue("@deptId", obj.deptId);



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
        //To delete Employee details
        public bool DeleteData(int Id)
        {
            int i = 0;
            string sqlQuery = "delete from Employee where EmployeeId=" + Id;
            connection();
            SqlCommand com = new SqlCommand(sqlQuery, con);



            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@EmployeeId", Id);



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
    
