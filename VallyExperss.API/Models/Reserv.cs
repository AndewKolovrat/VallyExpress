using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallyExpress.Models
{
    public class Reserv : Based.EntityBase
    {
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int Count { get; set; }

    }

}

