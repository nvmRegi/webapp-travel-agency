using System.ComponentModel.DataAnnotations;

namespace WebApp_Traverl_Agency.Models
{
    public class PacchettoViaggio
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Immagine { get; set; }
        public string Descrizione { get; set; }
        public int Durata { get; set; }
        public int NumeroDestinazioni { get; set; }
        public double Prezzo { get; set; }
        
        public PacchettoViaggio()
        {

        }
    }
}
