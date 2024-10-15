
using bookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace bookApp
{
    public class BookPositionRepository : IBookPositionRepository
    {
        private readonly BookAppContext _bookAppContext;
        private readonly BookInventoryGenerator _bookInventoryGenerator;

        public BookPositionRepository(BookAppContext bookAppContext, BookInventoryGenerator bookInventoryGenerator)
        {
            this._bookAppContext = bookAppContext;
            this._bookInventoryGenerator = bookInventoryGenerator;
            _bookInventoryGenerator = bookInventoryGenerator;
        }

        public async Task<string> AddBookPosition(BookPosition bookPosition)
        {
            try
            {
                // Ensure a new ID is assigned
                //bookPosition.Id = Guid.NewGuid();

                // Manually initialize the BookInventories collection if not done elsewhere
                if (bookPosition.BookInventories == null)
                {
                    bookPosition.BookInventories = new List<BookInventory>();
                }

                // Generate and add a new BookInventory entry
                var bookInventory = new BookInventory
                {
                    //Id = Guid.NewGuid(),
                    Condition = bookPosition.BookInventory.Condition,
                    //Inventory_Nr = "3665659674336|1" // Replace with real generation logic
                    Inventory_Nr = _bookInventoryGenerator.GenerateInventoryNr(bookPosition.ISBN) // Replace with real generation logic
                };

                bookPosition.BookInventories.Add(bookInventory);

                // Add the book position to the context
                await _bookAppContext.BookPositions.AddAsync(bookPosition);

                // Save changes to the database
                await _bookAppContext.SaveChangesAsync();

                return bookInventory.Inventory_Nr;
            }
            catch (Exception ex)
            {
                // Log the error and rethrow, or handle it as needed
                throw new Exception($"Error adding {bookPosition.Book.Title}: {ex.Message}", ex);
            }
            //try
            //{
            //    bookPosition.Id = Guid.NewGuid();
            //    //var bookInventory = new BookInventory()
            //    //{
            //    //    Inventory_Nr = _bookInventoryGenerator.GenerateInventoryNr(bookPosition.ISBN),
            //    //};
            //    //bookPosition.BookInventories.Add(bookInventory);
            //    //bookPosition.BookInventory.Inventory_Nr= _bookInventoryGenerator.GenerateInventoryNr(bookPosition.ISBN);
            //    bookPosition.BookInventory.Inventory_Nr= "3665659674337|1";
            //    _bookAppContext.Add(bookPosition);
            //    await _bookAppContext.SaveChangesAsync();

            //    return bookPosition.BookInventory.Inventory_Nr;

            //}
            //catch (Exception)
            //{
            //    throw new Exception($"Error adding {bookPosition.Book.Title}");
            //}
        }

        public List<BookPositionDTO> GetAllBookPositionsSortedByCreationDate()
        {
            List<BookPositionDTO> bookPositionsDtos = new List<BookPositionDTO>();
            try
            {
                bookPositionsDtos = _bookAppContext.Database.SqlQuery<BookPositionDTO>($"EXEC GetBookPositionsOrderedByCreationDate").AsEnumerable().ToList();

                return bookPositionsDtos;
            }
            catch (Exception)
            {

                return bookPositionsDtos;
            }

        }

        //private List<BookPosition> MapBookPositionsDtosToBookPositions(List<BookPositionDTO> bookPositionsDtos)
        //{
        //    List<BookPosition> bookPositions = new List<BookPosition>();
        //    foreach (var bookPositionDto in bookPositionsDtos)
        //    {
        //        BookPosition bookPosition = new BookPosition()
        //        {
        //            ISBN = bookPositionDto.ISBN,
        //            RentalFee = new RentalFee()
        //            {
        //                Value = bookPositionDto.RentalFee
        //            }
        //        }
        //        bookPositions.Add(bookPosition);
        //    }
        //}
    }
}
