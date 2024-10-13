
using bookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookApp
{
    public class BookPositionRepository : IBookPositionRepository
    {
        private readonly BookAppContext _bookAppContext;

        public BookPositionRepository(BookAppContext bookAppContext)
        {
            this._bookAppContext = bookAppContext;
        }

        public async Task<Guid> AddBookPosition(BookPosition bookPosition)
        {
            try
            {
                bookPosition.Id = Guid.NewGuid();
                _bookAppContext.Add(bookPosition);
                await _bookAppContext.SaveChangesAsync();

                return bookPosition.Id;

            }
            catch (Exception)
            {

                throw new Exception($"Error adding {bookPosition.Book.Title}");
            }
        }
    }
}
