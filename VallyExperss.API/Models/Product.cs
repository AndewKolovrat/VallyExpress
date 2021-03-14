
namespace VallyExpress.Models
{
    public class Product : Based.ProductBase
    {
        public string Model { get; set; }
        public int InReserved { get; set; }
        
        public Product()
        {
            this.Reserveds = new System.Collections.Generic.List<int>();
        }

        public System.Collections.Generic.List<int> Reserveds { get; set; }

        public virtual bool TryReserv(int count)
        {
            if (count <= 0) return false;
            if (count > this.Count) return false;
            this.Count -= count;
            this.InReserved += count;
            return true;
        }

        public static Product Sample()
        {
            Product p = new Product();
            p.Name = "Ыphone";
            p.Descriptions = "shit";
            p.Price = 1000;
            p.Count = 100;
            p.Reserveds = new System.Collections.Generic.List<int>();
            return p;
        }
    }

}
