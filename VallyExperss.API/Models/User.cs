using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallyExpress.Models
{
    public class User : Based.EntityBase
    {
        public User()
        {
            this.ReservedsID = new List<int>();
        }

        public string Name { get; set; }
        public List<int> ReservedsID { get; set; }

        static public User Sample()
        {
            return new User { Name = "TestUser" };
        }

    }

}
