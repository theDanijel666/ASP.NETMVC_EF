using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_CF.Models
{
    public class Author
    {
        [Key]
        [DisplayName("Šifra autora")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(200)]
        public string Prezime { get; set; }

        public string IAN { get; set; }
        public DateTime DatumRodjenja {  get; set; }
        public DateTime? DatumSmrti {  get; set; }
        public string? CV { get; set; }

        [Range(1,5,ErrorMessage ="Raiting mora biti između 1 i 5!")]
        public float Rating { get; set; }
    }
}
