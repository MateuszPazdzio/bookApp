using bookApp.Models;

namespace bookApp
{
    public interface IBookPositionRepository
    {
        Task<string> AddBookPosition(BookPosition bookPosition);
        List<BookPositionDTO> GetAllBookPositionsSortedByCreationDate();
    }
}
