using Entities;

namespace Repository
{
    public interface IratingRepository
    {
        Task<Rating> AddRating(Rating newRating);
    }
}