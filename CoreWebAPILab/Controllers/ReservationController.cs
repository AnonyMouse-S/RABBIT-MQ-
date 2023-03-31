using CoreWebAPILab.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IRepository repository;
        public ReservationController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public IEnumerable<Reservations> Get()
        {
            return repository.GetReservations();
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public Reservations Get(int id)
        {
            return repository.GetReservation(id);
        }

        // POST api/<ReservationController>
        [HttpPost]
        public Reservations Post([FromBody] Reservations res)
        {
            Reservations reservation = new Reservations();
            reservation.Name = res.Name;
            reservation.StartLocation = res.StartLocation;
            reservation.EndLocation = res.EndLocation;

            return repository.AddReservation(reservation);
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public Reservations Put(int id, [FromBody] Reservations res)
        {
            Reservations reservation = new Reservations();
            reservation.Name = res.Name;
            reservation.StartLocation = res.StartLocation;
            reservation.EndLocation = res.EndLocation;

            return repository.UpdateReservation(reservation);
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return repository.DeleteReservation(id);
        }
    }
}
