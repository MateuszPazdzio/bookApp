Select c.Name , COUNT(r.Id) as Liczba_wynajmów From Books as b
Inner Join Categories as c
	ON b.CategoryId = c.Id
Inner Join BookPositions as bp
	ON bp.BookId = b.Id
Inner Join BookInventories as bi
	ON bi.BookPositionId = bp.Id
Inner Join Rentals as r
	ON r.BookInventoryId = bi.Id
Where DATEDIFF(DAY,r.RentalDate,GetDate())<=90
Group By 
	c.Name
Order By
	Liczba_wynajmów
	DESC