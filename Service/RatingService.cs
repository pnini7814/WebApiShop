using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RatingService : IRatingService
    {
        IratingRepository IratingRepository;
        public RatingService(IratingRepository iratingRepository)
        {
            this.IratingRepository = iratingRepository;
        }
        public async Task<Rating> AddRating(Rating newRating)
        {
            return await IratingRepository.AddRating(newRating);
        }
    }
}
