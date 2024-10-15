using bookApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace bookApp
{
    public class BookInventoryGenerator
    {
        private readonly BookAppContext _bookAppContext;

        public BookInventoryGenerator(BookAppContext bookAppContext)
        {
            this._bookAppContext = bookAppContext;
        }
        public string GenerateInventoryNr(string isbn)
        {
            var sortedASCInventoryNr = _bookAppContext.BookPositions
                .Where(bp => bp.ISBN == isbn)
                .Include(bp => bp.BookInventories) // This may not be necessary, depending on your design
                .SelectMany(bp => bp.BookInventories) // Flatten the list of inventories
                .AsEnumerable()
                .OrderBy(bi => new InventoryNumberComparer())
                .ToList();

            // Example logic to generate an inventory number (replace with your logic)
            if (sortedASCInventoryNr.Any())
            {
                // Get the highest inventory number and increment it (example logic)
                var lastInventoryNr = sortedASCInventoryNr.Last().Inventory_Nr;
                var newInventoryNr = GenerateNextInventoryNr(lastInventoryNr);
                return newInventoryNr;
            }

            // If no inventory numbers exist, return a default or initial number
            return $"{isbn}|1"; // Or whatever the starting inventory number should be

        }

        private string GenerateNextInventoryNr(string lastInventoryNr)
        {
            // Assuming lastInventoryNr is of the format "INV-1"
            string[] parts = lastInventoryNr.Split('|');
            if (parts.Length < 2 || !Int32.TryParse(parts[1], out int lastNumber))
            {
                return "INV-1"; // Return default if parsing fails
            }

            int newNumber = lastNumber + 1; // Increment the number
            return $"{parts[0]}|{newNumber}"; // Return new inventory number
        }

        private class InventoryNumberComparer : IComparer<BookInventory>
        {
            public int Compare(BookInventory? x, BookInventory? y)
            {
                // Handle null values safely
                if (x == null && y == null) return 0;
                if (x == null) return 1; // Consider null to be greater
                if (y == null) return -1; // Consider null to be lesser

                // Split and compare the second part of the inventory number
                int result1, result2;
                if (Int32.TryParse(x.Inventory_Nr.Split('|')[1], out result1) &&
                    Int32.TryParse(y.Inventory_Nr.Split('|')[1], out result2))
                {
                    return result1.CompareTo(result2); // Use built-in comparison
                }

                // If parsing fails, decide how to handle the comparison
                return string.Compare(x.Inventory_Nr, y.Inventory_Nr, StringComparison.Ordinal);
            }
        }
    }
}
