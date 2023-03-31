namespace CoreWebAPILab.Models
{
    public interface IRepository
    {
        IEnumerable<Reservations> GetReservations();
        Reservations GetReservation(int id);
        Reservations AddReservation(Reservations reservation);
        Reservations UpdateReservation(Reservations reservation);
        bool DeleteReservation(int id);
    }
}