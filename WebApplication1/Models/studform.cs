using System.Data.SqlClient;
using System.Collections.Generic;

namespace WebApplication1.Models

{
    public class studform
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public studform(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("SqlConnection"));
        }

        public int AddStud(stud student)
        {
            int result = 0;
            string qry = "insert into stud values(@Name, @Surname, @DOB, @Gender, @Qualification, @Mobile_No, @Email)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Surname", student.Surname);
            cmd.Parameters.AddWithValue("@DOB", student.DOB);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Qualification", student.Qualification);
            cmd.Parameters.AddWithValue("@Mobile_No", student.Mobile_No);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;  
        }

        public int EditStud(stud student)
        {
            int result = 0;
            string qry = "update stud set Name=@Name, Surname=@Surname, DOB=@DOB, Gender=@Gender, Qualification=@Qualification, Mobile_No=@Mobile_No, Email=@Email where @Id=Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", student.Id);
            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Surname", student.Surname);
            cmd.Parameters.AddWithValue("@DOB", student.DOB);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Qualification", student.Qualification);
            cmd.Parameters.AddWithValue("@Mobile_No", student.Mobile_No);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int DeleteStud(stud student)
        {
            int result = 0;
            string qry = "delete from stud where @Id=Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", student.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public List<stud> StudList()
        {
            List<stud> list = new List<stud>();
            string qry = "select * from stud";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    stud l = new stud();
                    l.Id = Convert.ToInt32(dr["Id"]);
                    l.Name = dr["Name"].ToString();
                    l.Surname = dr["Surname"].ToString();
                    l.DOB = Convert.ToDateTime(dr["DOB"]);
                    l.Gender = dr["Gender"].ToString();
                    l.Qualification = dr["Qualification"].ToString();
                    l.Mobile_No = Convert.ToInt32(dr["Mobile_No"]);
                    l.Email = dr["Email"].ToString();
                    list.Add(l);
                }
            }
            con.Close();
            return list;
        }

        public stud StudDetails(int id)
        {
            stud l = new stud();
            string query = "select * from stud where Id=@Id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    l.Id = Convert.ToInt32(dr["Id"]);
                    l.Name = dr["Name"].ToString();
                    l.Surname = dr["Surname"].ToString();
                    l.DOB = Convert.ToDateTime(dr["DOB"]);
                    l.Gender = dr["Gender"].ToString();
                    l.Qualification = dr["Qualification"].ToString();
                    l.Mobile_No = Convert.ToInt32(dr["Mobile_No"]);
                    l.Email = dr["Email"].ToString();
                }
            }
            con.Close();
            return l;
        }

        public stud StudSearch(int id)
        {
            stud l = new stud();
            string query = "select * from stud where Id=@Id";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    l.Id = Convert.ToInt32(dr["Id"]);
                    l.Name = dr["Name"].ToString();
                    l.Surname = dr["Surname"].ToString();
                    l.DOB = Convert.ToDateTime(dr["DOB"]);
                    l.Gender = dr["Gender"].ToString();
                    l.Qualification = dr["Qualification"].ToString();
                    l.Mobile_No = Convert.ToInt32(dr["Mobile_No"]);
                    l.Email = dr["Email"].ToString();
                }
            }
            con.Close();
            return l;
        }
    }
}
