using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Assignment3DisplayUsers.Models
{
    public class DataAccessLayer
    {
        SqlConnection con;

        public DataAccessLayer()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Integrated Security=True; Initial Catalog = DemoDB";
        }
        public List<Users> GetAllUsers()
        {
            List<Users> lstRecipe = new List<Users>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Users";

            cmd.Connection = con;
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                lstRecipe.Add(
                    new Users
                    {
                        UserId = (int)sdr[0],
                        UserName = sdr[1].ToString(),
                        City = sdr[2].ToString(),
                        State = sdr[3].ToString(),
                        Country = sdr[4].ToString()
                    }
                    ); ;
            }
            sdr.Close();
            con.Close();

            return lstRecipe;
        }
        
        //public void AddRecipe(Recipe rec)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "insert into recipe values(@cId,@Rname,@pic,@desc)";
        //    cmd.Parameters.AddWithValue("@cId", rec.CategoryId);
        //    cmd.Parameters.AddWithValue("@Rname", rec.RecipeName);
        //    cmd.Parameters.AddWithValue("@pic", rec.Picture);
        //    cmd.Parameters.AddWithValue("@desc", rec.Description);

        //    cmd.Connection = con;
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}

        //public void DeleteRecipe(int catId)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "delete from recipe where categoryid = @cId";
        //    cmd.Parameters.AddWithValue("@cId", catId);


        //    cmd.Connection = con;
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        //public void UpdateRecipe(Recipe rec)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandText = "update tbl_employee set recipename=@Rname,picture=@pic,description=@desc where categoryid=@cId";
        //    cmd.Parameters.AddWithValue("@cId", rec.CategoryId);
        //    cmd.Parameters.AddWithValue("@Rname", rec.RecipeName);
        //    cmd.Parameters.AddWithValue("@pic", rec.Picture);
        //    cmd.Parameters.AddWithValue("@desc", rec.Description);


        //    cmd.Connection = con;
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //}
        public Users GetUserById(int userId)
        {
            Users r = null;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Users where Id=@uId";

            cmd.Parameters.AddWithValue("@uId", userId);
            cmd.Connection = con;
            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                r = new Users
                {
                    UserId = (int)sdr[0],
                    UserName = sdr[1].ToString(),
                     City= sdr[2].ToString(),
                    State = sdr[3].ToString(),
                    Country=sdr[4].ToString()
                };

            }
            sdr.Close();
            con.Close();

            return r;

        }
    }

}