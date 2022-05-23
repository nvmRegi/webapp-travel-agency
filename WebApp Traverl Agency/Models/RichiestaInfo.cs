using System.ComponentModel.DataAnnotations;

namespace WebApp_Traverl_Agency.Models
{
    public class RichiestaInfo
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Il campo Nome è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il nome non può avere più di 20 caratteri")]
        public string NomeUtente { get; set; }

        [Required(ErrorMessage = "Il campo Cognome è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il cognome non può avere più di 20 caratteri")]
        public string CognomeUtente { get; set; }

        [Required(ErrorMessage = "Il campo Email è obbligatorio")]
        public string EmailUtente { get; set; }

        [Required(ErrorMessage = "Il campo Richiesta è obbligatorio")]
        public string Richiesta { get; set; }

        public int PacchettoViaggioId { get; set; }
        public PacchettoViaggio PacchettoViaggio { get; set; }

        public RichiestaInfo() { }
    }
}
