using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VallyExpress.Models;

namespace VallyExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservController : ControllerBase
    {
        private IShop shop { get; set; }

        public ReservController(IShop shop)
        {
            this.shop = shop;
        }

        [HttpGet]
        public IEnumerable<Reserv> Get()
        {
            return shop.GetReservs();
        }

        
        [HttpGet("{id}")]
        public Reserv Get(int id)
        {
            return shop.GetReservs(id);
        }

    }

}
