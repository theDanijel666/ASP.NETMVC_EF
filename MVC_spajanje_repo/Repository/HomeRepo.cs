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
                            Ime = (string)reader["imeStud"],
                            Prezime = (string)reader["prezStud"],
                            Mjesto_Rodjenja = (int)reader["pbrRod"],
                            Mjesto_Stanovanja = (int)reader["pbrStan"],
                            Datum_rodjenja = (DateTime)reader["datRodStud"],
                            JMBG = (string)reader["jmbgStud"]
                        };
                        studenti.Add(s);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return studenti;
        }

    }
}
