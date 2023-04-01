using CoreWebAPILab.Models;
using CoreWebAPILab.RabbitMQ;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreWebAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IRepository repository;
        private IRabitMQProducer rabitMQProducer;

        public ReservationController(IRepository repository, IRabitMQProducer rabitMQProducer)
        {
            this.repository = repository;
            this.rabitMQProducer = rabitMQProducer;
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
            Reservations reservation = repository.AddReservation(res);

            //send the inserted product data to the queue and consumer will lisen this data from queue
            rabitMQProducer.SendMessage(reservation);

            return reservation;
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public Reservations Put(int id, [FromBody] Reservations res)
        {
            res.Id = id;
            return repository.UpdateReservation(res);
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return repository.DeleteReservation(id);
        }
    }
}
