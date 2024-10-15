using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models
{
    public class RaportIncome
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateOnly IncomeCalculationStartDate { get; set; }
        [Precision(10, 2)]
        public decimal SalesIncome { get; set; }
        public int SalesQuantity { get; set; }
        [Precision(10, 2)]
        public decimal RentalIncome { get; set; }
        public int RentalQuantity { get; set; }
        [Precision(10, 2)]
        public decimal TotalIncome { get; set; }
    }
    //selecting bookpositions which stock value is less than 3, order by StoreQuantity 
/*//Procedure(@ transactionType)
 */
    public class RaportCrisisBookPositionQuantity
    {
        //public int Id { get; set; }
        public BookPosition BookPosition { get; set; }
    }

    //Procedure(@ transactionType)
    //grouped by category later by author, later by title (inner order by Count(transactionType) descending) + how many times it reached below crisis limit
    public class CategoryPopularity
    {

    }
}
