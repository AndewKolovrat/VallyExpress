
using System.ComponentModel.DataAnnotations.Schema;

namespace VallyExpress.Data
{
    public class Reserv : BaseEntity
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public User User { get; set; }
    }

}
