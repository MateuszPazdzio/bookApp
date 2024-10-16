CREATE PROCEDURE GetBookPositionsOrderedByCreationDate
AS
BEGIN
    SET NOCOUNT ON;
	
	WITH NumberedBooks AS (
    SELECT 
        bp.ISBN,
        b.Title AS [Title],
        bc.Name AS [CoverType],
        bp.IsTransferableToStore AS [IsTransferableToStore],
        bp.SellingPrice AS [SellingPrice],
        bp.RentalFee AS [RentalFee],
        bp.CreationDate AS [CreationDate],
		bp.LateFee AS [LateFee],
        COUNT(bi.Inventory_Nr) OVER(PARTITION BY bp.ISBN) AS BookPositionCount, 
        ROW_NUMBER() OVER(PARTITION BY bp.ISBN ORDER BY bp.CreationDate) AS RowNum 
    FROM 
        dbo.BookPositions bp
    JOIN 
        dbo.Books b ON bp.BookId = b.Id 
    JOIN 
        dbo.BookCovers bc ON bp.BookCoverId = bc.Id 
    LEFT JOIN 
        dbo.BookInventories bi ON bp.Id = bi.BookPositionId 
)
SELECT 
    ISBN,
    [Title],
    [CoverType],
    [IsTransferableToStore],
    [SellingPrice],
    [RentalFee],
    [CreationDate],
	[LateFee],
    BookPositionCount
FROM 
    NumberedBooks
WHERE 
    RowNum = 1 
ORDER BY 
    CreationDate DESC;

END;

Exec GetBookPositionsOrderedByCreationDate