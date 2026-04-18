using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ratingRepository : IratingRepository
    {
        private readonly WebApiShopDBContext webApiShopDB;
        public ratingRepository(WebApiShopDBContext webApiShopDB)
        {
            this.webApiShopDB = webApiShopDB;
        }
        public async Task<Rating> AddRating(Rating newRating)
        {
            //await webApiShopDB.Rating.AddRating(newRating);
            //await webApiShopDB.SaveChangesAsync();
            return newRating;

        }
    }
}
