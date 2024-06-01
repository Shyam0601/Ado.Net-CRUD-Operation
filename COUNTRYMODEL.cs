using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace CRUDMVCCLASS.Models
{
    public class COUNTRYMODEL
    {
        public DataTable GetAllCountry()
        {

            DataTable datatable = new DataTable();
            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from country", con);
               
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(datatable);
            }
            return datatable;
        }
        public DataTable GetCountryByID(int intcountryId)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from country where countryId=" + intcountryId, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public int Updatecountry(int intcountryId, string strcountryName,bool isactive)
        {
            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Update country SET countryName=@conname,isactive=@isactive where countryId=@countryId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@conname", strcountryName);
                cmd.Parameters.AddWithValue("@isactive", isactive);
                cmd.Parameters.AddWithValue("@countryId", intcountryId);
                return cmd.ExecuteNonQuery();
            }
        }
        public int Insertcountry(string strcountryName, bool isactive)
        {
            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Insert into country (countryName,isactive) values(@conname,@isactive)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@conname", strcountryName);
                cmd.Parameters.AddWithValue("@isactive", isactive);

                return cmd.ExecuteNonQuery();
            }
        }
        public int Deletecountry(int intcountryId)
        {
            string strConString = @"Data Source=DESKTOP-A9EI6OG;Initial Catalog=sampleproject;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                string query = "Delete from country where countryId=@conid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@conid", intcountryId);
                return cmd.ExecuteNonQuery();
            }
        }

        internal DataTable GetCountryByID(object intcountryId)
        {
            throw new NotImplementedException();
        }

    }
}