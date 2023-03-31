namespace CoreWebAPILab.Models
{
    public class Repository : IRepository
    {
        private ReservationContext context;

        public Repository(ReservationContext reservationContext)
        {
            this.context = reservationContext;
        }

        public Reservations AddReservation(Reservations reservation)
        {
            context.Reservations.Add(reservation);
            context.SaveChanges();

            return reservation;
        }

        public bool DeleteReservation(int id)
        {
            Reservations? reservations = context.Reservations.Where(x => x.Id == id).FirstOrDefault();
            if (reservations != null)
            {
                context.Remove(reservations);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Reservations? GetReservation(int id)
        {
            Reservations? reservations = context.Reservations.Where(x => x.Id == id).FirstOrDefault();
            return reservations;
        }

        public IEnumerable<Reservations> GetReservations()
        {
            return context.Reservations.ToList();
        }

        public Reservations UpdateReservation(Reservations reservation)
        {            
            context.Reservations.Update(reservation);
            context.SaveChanges();
            return reservation;
        }
    }
}