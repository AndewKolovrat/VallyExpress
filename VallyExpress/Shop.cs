using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using VallyExpress.Data;

namespace VallyExpress
{

    public class Shop
    {
        ShopContent db = new ShopContent();
        
        public async Task<IEnumerable<Phone>> testAsync()
        {
            // Create
            Console.WriteLine("Inserting a new blog");
            db.Add( Phone.Sample()  );
            db.SaveChanges();

            // Read
            Console.WriteLine("Querying for a blog");
            return await db.Phones.ToListAsync();
        }
    }

}
