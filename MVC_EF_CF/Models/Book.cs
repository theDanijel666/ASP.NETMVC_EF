using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_CF.Models
{
    public class Book
    {
        [Key]
        [DisplayName("Šifra knjige")]
        public int Id { get; set; }
        [Required]
        public string Naslov { get; set; }
        public string ISBN { get; set; }
        public DateTime DatumObjave {  get; set; }


        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
