using Microsoft.EntityFrameworkCore;

namespace CoreWebAPILab.Models
{
    public class ReservationContext: DbContext
    {
        public ReservationContext()
        {

        }
        public DbSet<Reservations> Reservations { get; set; }
    }
}