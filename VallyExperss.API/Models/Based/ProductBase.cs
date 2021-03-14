using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallyExpress.Models.Based
{
    public abstract class ProductBase : EntityBase
    {
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public int Price { get; set; }
        
        public int Count { get; set; }

    }

}
