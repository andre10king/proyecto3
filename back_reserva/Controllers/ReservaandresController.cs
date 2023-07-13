
using back_reserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace back_reserva.Controllers
{
 [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    public class ReservaandresController : ApiController
    {
        // GET: api/Mascota
        public IEnumerable<Reservaandres> Get()
        {
            GestorReservaandres gReservaandres = new GestorReservaandres();
            return gReservaandres.GetReservaandres();
        }

        // GET: api/Mascota/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mascota
        public bool Post([FromBody] Reservaandres reservaandres)
        {
            GestorReservaandres gReservaandres = new GestorReservaandres();
            bool res = gReservaandres.addReserva(reservaandres);
            return res;
        }

        // PUT: api/Mascota/5
        public bool Put(int id, [FromBody] Reservaandres reservaandres)
        {
            GestorReservaandres gReservaandres = new GestorReservaandres();
            bool res = gReservaandres.updateReserva(id, reservaandres);
            return res;
        }

        // DELETE: api/Mascota/5
        public bool Delete(int id)
        {
            GestorReservaandres gReservaandres = new GestorReservaandres();
            bool res = gReservaandres.deleteReserva(id);
            return res;
        }
    }
}
