using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApp_Traverl_Agency.Models
{
    public class PacchettoViaggio
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Il campo Immagine è obbligatorio")]
        public string Immagine { get; set; }
        [Required(ErrorMessage = "Il campo Descrizione è obbligatorio")]
        public string Descrizione { get; set; }
        [Required(ErrorMessage = "Il campo Durata è obbligatorio")]
        public int Durata { get; set; }
        [Required(ErrorMessage = "Il campo Numero di Destinazioni è obbligatorio")]
        public int NumeroDestinazioni { get; set; }
        [Required(ErrorMessage = "Il campo Prezzo è obbligatorio")]
        public double Prezzo { get; set; }

        [JsonIgnore]
        public List<RichiestaInfo> RichiesteInfo { get; set; }
         
        public PacchettoViaggio()
        {

        }
    }
}
