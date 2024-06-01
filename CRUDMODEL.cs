using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;
namespace CRUDMVCCLASS.Models
{

    public class CRUDMODEL
    {
     
        public DataTable GetAllStudents()
        {

            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select a.studentId, a.studentName,a.Age,a.Address,b.countryName,a.isactive from student as a left join country as b on a.countryId=b.countryId", con);
                  SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetstudentByID(int intstudentId)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from student where studentId=" + intstudentId, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public int Updatestudent(int intstudentId, string strstudentName, string strAddress, int intAge, int intcountryId, bool isactive)
        {
            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Update student SET studentName=@studname,  Age=@studage , Address=@address,countryId=@countryid,isactive=@isactive where studentId=@studid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studname", strstudentName);
                cmd.Parameters.AddWithValue("@studage", intAge);
                cmd.Parameters.AddWithValue("@address", strAddress);
                cmd.Parameters.AddWithValue("@countryid", intcountryId);
                cmd.Parameters.AddWithValue("@isactive", isactive);
                cmd.Parameters.AddWithValue("@studid", intstudentId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Insertstudent(string strStudentName, string strAddress, int intAge, int intcountryId, bool isactive)
        {
            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into student (studentName, Age,Address,countryId,isactive) values(@studname, @studage , @Address,@countryid,@isactive)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studname", strStudentName);
                cmd.Parameters.AddWithValue("@studage", intAge);
                cmd.Parameters.AddWithValue("@Address", strAddress);
                cmd.Parameters.AddWithValue("@countryid", intcountryId);
                cmd.Parameters.AddWithValue("@isactive", isactive);

                return cmd.ExecuteNonQuery();
            }
        }

        public int Deletestudent(int intstudentId)
        {
            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from student where studentId=@studid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studid", intstudentId);
                return cmd.ExecuteNonQuery();
            }
        }
        public DataTable CountryList()
        {
            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                DataTable dtbl = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * from country", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtbl);

                //List<country> docTypes = new List<country>();
                //docTypes = (from DataRow dr in dtbl.Rows
                //            select new country
                //            {
                //                countryId = Convert.ToInt32(dr["CountryId"]),
                //                countryName = dr["countryName"].ToString(),
                //            }).ToList();

                return dtbl;
            }


        }

        internal DataTable GetstudentByID(object intstudentId)
        {
            throw new NotImplementedException();
        }

    }
    public class country
    {
        public int countryId { get; set; }
        public string countryName { get; set; }
    }

    public class DocViews
    {
       
        public country country { get; set; }

        public List<country> countryList { get; set; }
      
    }
}
