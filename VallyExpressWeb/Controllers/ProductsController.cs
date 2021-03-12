using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VallyExpress.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VallyExpress.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private DataContext db;

        public ProductsController(ILogger<ProductsController> logger, DataContext context)
        {
            _logger = logger;
            db = context;
            if (!db.Products.Any())
            {
                db.Products.Add(new Product { Name = "Ыphone" });
                db.SaveChanges();
            }
        }

        // GET: api/<PhonesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
