using Microsoft.EntityFrameworkCore;
using WebApp_Traverl_Agency.Models;

namespace WebApp_Traverl_Agency.Data
{
    public class TravelContext : DbContext
    {
        public DbSet<PacchettoViaggio> Pacchetto_Viaggio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=travel_agency;Integrated Security=True");
        }
    }
}
