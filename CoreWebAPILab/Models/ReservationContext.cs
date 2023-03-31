using Microsoft.EntityFrameworkCore;

namespace CoreWebAPILab.Models
{
    public class ReservationContext: DbContext
    {
        public ReservationContext(DbContextOptions<ReservationContext> options):base(options)
        {

        }
        public DbSet<Reservations> Reservations { get; set; }
    }
}