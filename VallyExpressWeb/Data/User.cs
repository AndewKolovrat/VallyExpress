using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VallyExpress.Data
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public List<Reserv> ReservedItems { get; set; }

    }

}
