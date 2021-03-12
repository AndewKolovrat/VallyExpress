using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VallyExpress.Data
{
    public abstract class ProductItem : BaseEntity
    {
        public int Count { get; set; }
        public int InReserved { get; set; }

    }

}
