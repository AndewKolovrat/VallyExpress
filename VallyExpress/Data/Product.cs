
namespace VallyExpress.Data
{
    public class Phone : Based.ProductBase
    {
        public string Model { get; set; }      
        
        public static Phone Sample()
        {
            Phone p = new Phone();
            p.Name = "Ыphone";
            p.Descriptions = "shit";
            p.Price = 1000;
            p.Count = 789;
            return p;
        }
    }

}
