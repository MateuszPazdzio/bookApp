CREATE PROCEDURE CalculateLateFee
    @RentalId int
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @LateFeeValue DECIMAL(10, 2);
    DECLARE @ExpectedReturnDate DATETIME;
    DECLARE @RentalDate DATETIME;
    DECLARE @ActualReturnDate DATETIME;
    DECLARE @CustomerId int; -- Variable to store CustomerId
	--Set @RentalId = '8771F48C-E5E4-4278-B604-715107B8E1F1'
    -- Pobierz dane wypo¿yczenia i spóŸnion¹ op³atê
    SELECT 
        @ExpectedReturnDate = ExpectedReturnDate,
        @RentalDate = RentalDate,
        @ActualReturnDate = ActualReturnDate,
        @LateFeeValue = bp.LateFee,
        @CustomerId = t.CustomerId -- Retrieve CustomerId
    FROM 
        dbo.Rentals r
    JOIN 
        dbo.BookPositions bp ON r.BookPositionId = bp.Id
    JOIN 
        dbo.Transactions t ON r.TransactionId = t.Id -- Join to get CustomerId
    WHERE 
        r.Id = @RentalId;

    -- Sprawdzenie, czy rzeczywista data zwrotu nie istnieje
    IF @ActualReturnDate IS NULL
    BEGIN
        -- Oblicz liczbê dni spóŸnienia
        DECLARE @DaysLate INT;
        SET @DaysLate = DATEDIFF(DAY, @ExpectedReturnDate, GETDATE());
		print @DaysLate
        -- SprawdŸ, czy dni spóŸnienia s¹ wiêksze od zera
        IF @DaysLate > 0
        BEGIN
            DECLARE @TotalLateFee DECIMAL(10, 2);
            SET @TotalLateFee = @DaysLate * @LateFeeValue;
			print @TotalLateFee
            -- SprawdŸ, czy LateFee ju¿ istnieje
            IF EXISTS (SELECT 1 FROM dbo.LateFees WHERE RentalId = @RentalId)
            BEGIN
				print 'istnieje'
                -- Aktualizuj istniej¹c¹ op³atê
                UPDATE dbo.LateFees
                SET Value = @TotalLateFee
                WHERE RentalId = @RentalId;
            END
            ELSE
            BEGIN
				print 'nie istnieje'
                -- Stwórz now¹ op³atê
                INSERT INTO dbo.LateFees (RentalId, Value,IsPaid)
                VALUES (@RentalId, @TotalLateFee,0);
            END
            
            -- Zaktualizuj kolumnê IsBlocked w tabeli Customer
            UPDATE dbo.Customers
            SET IsBlocked = 1 -- Set IsBlocked to true
            WHERE Id = @CustomerId; -- Use the retrieved CustomerId
        END
    END
END;

Exec CalculateLateFee 18