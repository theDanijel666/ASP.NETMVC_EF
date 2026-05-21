using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using MVC_spajanje_repo.Models;

namespace MVC_spajanje_repo.Repository
{
    public class HomeRepo
    {
        private readonly IConfiguration _configuration;

        public HomeRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CheckConnection()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Baza")))
                {
                    con.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studenti = new List<Student>();

            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Baza")))
                {
                    SqlCommand com = new SqlCommand("SELECT * FROM stud", con);
                    con.Open();
                    var reader=com.ExecuteReader();
                    while (reader.Read()) {
                        var s = new Student()
                        {
                            Mbr = (int)reader["mbrStud"],
                            Ime = (string?)reader["imeStud"],
                            Prezime = (string?)reader["prezStud"]
                        };
                        if(reader["pbrRod"]!=DBNull.Value) s.Mjesto_Rodjenja = (int?)reader["pbrRod"];
                        if(reader["pbrStan"]!=DBNull.Value) s.Mjesto_Stanovanja = (int?)reader["pbrStan"];
                        if(reader["datRodStud"]!=DBNull.Value) s.Datum_rodjenja = (DateTime?)reader["datRodStud"];
                        if (reader["jmbgStud"] != DBNull.Value) s.JMBG = (string?)reader["jmbgStud"];

                        studenti.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return studenti;
        }

        public Student GetStudentById(int mbrs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Baza")))
                {
                    SqlCommand com = new SqlCommand("SELECT * FROM stud where mbrStud=@mbrs", con);
                    com.Parameters.Add("@mbrs",System.Data.SqlDbType.Int).Value=mbrs;
                    con.Open();
                    var reader=com.ExecuteReader();
                    Student s=new Student();
                    while (reader.Read())
                    {
                        s.Mbr = (int)reader["mbrStud"];
                        s.Ime = (string?)reader["imeStud"];
                        s.Prezime = (string?)reader["prezStud"];
                        if (reader["pbrRod"] != DBNull.Value) s.Mjesto_Rodjenja = (int?)reader["pbrRod"];
                        if (reader["pbrStan"] != DBNull.Value) s.Mjesto_Stanovanja = (int?)reader["pbrStan"];
                        if (reader["datRodStud"] != DBNull.Value) s.Datum_rodjenja = (DateTime?)reader["datRodStud"];
                        if (reader["jmbgStud"] != DBNull.Value) s.JMBG = (string?)reader["jmbgStud"];

                        return s;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        public bool DeleteStudent(int mbrs)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Baza")))
                {
                    SqlCommand com = new SqlCommand("Delete * FROM stud where mbrStud=@mbrs", con);
                    com.Parameters.Add("@mbrs", System.Data.SqlDbType.Int).Value = mbrs;
                    con.Open();
                    int rows=com.ExecuteNonQuery();
                    if (rows == 1) return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        //public Student getByID(string id)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Baza")))
        //        {
        //            id = "0 or 1=1;Drop table stud; --";
        //            SqlCommand com = new SqlCommand("SELECT * FROM stud mbrStud=" + id, con);
        //            con.Open();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

    }
}
