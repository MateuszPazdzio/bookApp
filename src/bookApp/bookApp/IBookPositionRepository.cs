using bookApp.Models;

namespace bookApp
{
    public interface IBookPositionRepository
    {
        Task<Guid> AddBookPosition(BookPosition bookPosition);
    }
}
