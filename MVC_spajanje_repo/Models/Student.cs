namespace MVC_spajanje_repo.Models
{
    public class Student
    {
        public int Mbr {  get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Mjesto_Rodjenja { get; set; }
        public int Mjesto_Stanovanja { get; set; }
        public DateTime Datum_rodjenja { get; set; }
        public string JMBG { get; set; }
    }
}
