CREATE PROCEDURE InsertRaportIncome
    @IncomeCalculationStartDate DATE
AS
	BEGIN 
        DECLARE @SalesIncome DECIMAL(10, 2) = (
            SELECT SUM(Value)
            FROM Sales
            WHERE SaleDate > @IncomeCalculationStartDate
        );

        DECLARE @SalesQuantity INT = (
            SELECT COUNT(*)
            FROM Sales
            WHERE SaleDate > @IncomeCalculationStartDate
        );

        DECLARE @RentalIncome DECIMAL(10, 2) = (
            SELECT SUM(rf.Value)
            FROM Rentals AS r
            RIGHT JOIN RentalFees AS rf ON r.Id = rf.RentalId
            WHERE rf.IsPaid = 1 AND r.RentalDate > @IncomeCalculationStartDate
        );
		DECLARE @RentalQuantity INT = (
            SELECT count(*)
            FROM Rentals AS r
            Full JOIN RentalFees AS rf ON r.Id = rf.RentalId
            WHERE rf.IsPaid = 1 AND r.RentalDate > @IncomeCalculationStartDate
        );

        DECLARE @LateFeeIncome DECIMAL(10, 2) = (
            SELECT SUM(lf.Value)
            FROM Rentals AS r
            FULL JOIN LateFees AS lf ON r.Id = lf.RentalId
            WHERE lf.IsPaid = 1 AND r.RentalDate > @IncomeCalculationStartDate
        );

        DECLARE @TotalIncome DECIMAL(10, 2) = ISNULL(@SalesIncome, 0) + ISNULL(@RentalIncome, 0) + ISNULL(@LateFeeIncome, 0);

        INSERT INTO RaportsIncome (IncomeCalculationStartDate, CreationDate, SalesIncome, SalesQuantity, RentalIncome, RentalQuantity, TotalIncome)
        VALUES (@IncomeCalculationStartDate,GETDATE(), ISNULL(@SalesIncome, 0), ISNULL(@SalesQuantity, 0), ISNULL(@RentalIncome, 0) + ISNULL(@LateFeeIncome, 0),ISNULL(@RentalQuantity,0), @TotalIncome);

	END 
	exec InsertRaportIncome '2024-10-01'