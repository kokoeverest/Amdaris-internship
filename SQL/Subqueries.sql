USE AdventureWorks2019;

------ 1. View all employees with their payment rates and rates history
--SELECT pp.BusinessEntityID,
--	   CONCAT(pp.FirstName, ' ', pp.LastName) AS 'Fullname',
--	   pay.Rate AS 'Pay rate',
--	   (SELECT emp.JobTitle FROM [HumanResources].[Employee] AS emp
--	   WHERE emp.BusinessEntityID = pp.BusinessEntityID) AS 'Job title'

--FROM [Person].[Person] AS pp, [HumanResources].[EmployeePayHistory] AS pay
--WHERE pp.BusinessEntityID = pay.BusinessEntityID AND pp.BusinessEntityID IN (SELECT BusinessEntityID FROM [HumanResources].[Employee])
--GROUP BY pp.BusinessEntityID, pp.FirstName, pp.LastName, pay.Rate


---- 2. Changing productID with product Name
--SELECT TOP (100)
--	    sod.[SalesOrderID],
--      sod.[SalesOrderDetailID],
--      sod.[CarrierTrackingNumber],
--      sod.[OrderQty],
--      pp.[Name],
--      sod.[SpecialOfferID],
--      sod.[UnitPrice],
--      sod.[UnitPriceDiscount],
--      sod.[LineTotal]
--	   FROM [Production].[Product] pp JOIN 
--[Sales].[SalesOrderDetail] sod ON sod.ProductID = pp.ProductID

-- The same script using subqueries
--SELECT TOP (100)
--	  sod.[SalesOrderID],
--      sod.[SalesOrderDetailID],
--      sod.[CarrierTrackingNumber],
--      sod.[OrderQty],
--      (SELECT pp.[Name] FROM [Production].[Product] AS pp WHERE sod.ProductID = pp.ProductID) AS 'Product Name',
--      sod.[SpecialOfferID],
--      sod.[UnitPrice],
--      sod.[UnitPriceDiscount],
--      sod.[LineTotal]
--FROM [Sales].[SalesOrderDetail] AS sod


---- 3. Vendors details
--SELECT poh.VendorID,
--	  (SELECT v.Name FROM [Purchasing].[Vendor] AS v 
--    WHERE v.BusinessEntityID = poh.VendorID) As 'Vendor Name',
--	  SUM(poh.TotalDue) AS 'Total due'
--FROM [AdventureWorks2019].[Purchasing].[PurchaseOrderHeader] As poh
--GROUP BY poh.VendorID
--ORDER BY SUM(poh.TotalDue) DESC


---- 4. View all the vendor's representatives

SELECT ven.Name AS 'Vendor name',
	   CONCAT(pp.FirstName, ' ', pp.LastName) AS 'Representative name'
FROM [Person].[Person] AS pp, [Purchasing].[Vendor] AS ven
WHERE pp.BusinessEntityID in (SELECT bc.PersonID FROM [Person].[BusinessEntityContact] AS bc
WHERE ven.BusinessEntityID = bc.BusinessEntityID)
GROUP BY ven.Name, pp.FirstName, pp.LastName

-- 5. View the scrapped products
--SELECT pp.ProductID,
--		pp.[Name] AS 'Product name',
--		SUM(wo.[ScrappedQty]) as 'Total',
--		COUNT(DISTINCT wo.ScrapReasonID) AS 'Reasons'
--FROM [Production].[Product] pp JOIN
--[Production].[WorkOrder] wo ON pp.ProductID = wo.ProductID JOIN
--[Production].[ScrapReason] sr ON wo.ScrapReasonID = sr.ScrapReasonID
--GROUP BY pp.Name, pp.ProductID
--ORDER BY SUM(wo.[ScrappedQty]) DESC


-- The same script using subqueries
--SELECT pp.ProductID,
--	   pp.[Name] AS 'Product name',

--	   (SELECT  SUM(wo.[ScrappedQty]) FROM Production.WorkOrder AS wo
--	   WHERE wo.ProductID = pp.ProductID) as 'Total',

--	   (SELECT COUNT(DISTINCT wo.ScrapReasonID) FROM Production.WorkOrder AS wo
--	   WHERE wo.ProductID = pp.ProductID)  AS 'Reasons'

--FROM Production.Product AS pp
--ORDER BY (SELECT SUM(wo.ScrappedQty) FROM Production.WorkOrder AS wo WHERE wo.ProductID = pp.ProductID) DESC


---- 6. View the product's quantity by Location
--SELECT pl.[Name],
--       SUM([Quantity]) AS 'Total quantity'
--FROM [AdventureWorks2019].[Production].[Location] pl JOIN
--[Production].[ProductInventory] pnv ON pl.LocationID = pnv.LocationID
--GROUP BY pl.[Name]
--order by SUM(quantity) desc


---- The same using subqueries
--SELECT pl.Name,

--	(SELECT SUM(pnv.Quantity) FROM Production.ProductInventory AS pnv WHERE pl.LocationID = pnv.LocationID) AS 'Total quantity'

--FROM Production.Location AS pl
--ORDER BY (SELECT SUM(Quantity) FROM Production.ProductInventory WHERE pl.LocationID = LocationID) DESC

---- 7. View all the job candidates who started job as a Sales Person

--SELECT pp.BusinessEntityID,
--		CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS 'Full name',
--		pp.Title,
--		pp.PersonType,
--		sp.SalesYTD
--FROM [Person].[Person] pp JOIN
--[HumanResources].[JobCandidate] jc ON jc.BusinessEntityID = pp.BusinessEntityID JOIN
--[Sales].[SalesPerson] sp ON jc.BusinessEntityID = sp.BusinessEntityID


---- The same using subqueries
--SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS 'Full name',
--		pp.Title,
--		pp.PersonType,
--		(SELECT sp.SalesYTD FROM Sales.SalesPerson AS sp
--		WHERE pp.BusinessEntityID = sp.BusinessEntityID) as 'SalesYTD'
		
--FROM [Person].[Person] pp
--WHERE pp.BusinessEntityID IN 
--	(SELECT jc.BusinessEntityID FROM [HumanResources].[JobCandidate] AS jc WHERE jc.BusinessEntityID IN 
--	(SELECT sp.BusinessEntityID FROM Sales.SalesPerson AS sp WHERE jc.BusinessEntityID = sp.BusinessEntityID))


---- 8. View all discounted products with their prices
--SELECT pp.ProductID,
--	   pp.Name,
--	   pp.ListPrice,
--	   (1 - so.DiscountPct) * pp. ListPrice  AS 'Discounted price',
--	   SUM(pp. ListPrice * so.DiscountPct) AS 'Discount'
--FROM [Production].[Product] pp JOIN
--[Sales].[SpecialOfferProduct] sop ON sop.ProductID = pp.ProductID JOIN
--[Sales].[SpecialOffer] so ON so.SpecialOfferID = sop.SpecialOfferID
--WHERE so.DiscountPct > 0
--GROUP BY pp.ProductID, pp.ListPrice, pp. Name, so.DiscountPct
--ORDER BY SUM(pp. ListPrice * so.DiscountPct) DESC


--SELECT pp.ProductID,
--	   pp.Name,
--	   pp.ListPrice,
--	   (1 - so.DiscountPct) * pp.ListPrice  AS 'Discounted price',
--	   (pp.ListPrice * so.DiscountPct)  AS 'Discount' 
--FROM [Production].[Product] AS pp, Sales.SpecialOfferProduct AS sop, Sales.SpecialOffer AS so
--WHERE so.DiscountPct > 0 AND sop.ProductID = pp.ProductID AND so.SpecialOfferID = sop.SpecialOfferID AND pp.ListPrice > 0
--GROUP BY pp.ProductID, pp.ListPrice, pp. Name, so.DiscountPct
--ORDER BY SUM(pp. ListPrice * so.DiscountPct) DESC



--SELECT ProductNumber,
--	Category = CASE ProductLine
--		WHEN 'R' THEN 'Road'
--		WHEN 'M' THEN 'Mountain'
--		WHEN 'T' THEN 'Touring'
--		WHEN 'S' THEN 'Otehr sale items'
--		ELSE 'Not for sale'
--		END,
--	Name
--FROM Production.Product
--ORDER BY ProductNumber
