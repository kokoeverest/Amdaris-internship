USE AdventureWorks2019;

---- 1. View all cards by type, which expire at a certain point
--SELECT COUNT([CreditCardID]) as 'Cards count'
--      ,[CardType]
--  FROM [AdventureWorks2019].[Sales].[CreditCard]
--  WHERE ExpYear = 2005 AND ExpMonth = 6
--  GROUP BY CardType;


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


---- 3. Order details
--SELECT [SalesOrderID],
--	  COUNT([SalesOrderID]) AS 'Products in order',
--	  SUM([LineTotal]) AS 'Total order cost',
--	  AVG(LineTotal) AS 'Average order cost',
--	  MIN(UnitPrice) AS 'Cheapest product',
--	  MAX(UnitPrice) AS 'Most expensive product'
--FROM [Sales].[SalesOrderDetail]
--GROUP BY [SalesOrderID]


---- 4. View the most productive employees
--SELECT EmployeeID,
--      COUNT([EmployeeID]) as 'Orders processed'
      
--  FROM [AdventureWorks2019].[Purchasing].[PurchaseOrderHeader]
--  Group by EmployeeID
--  ORDER BY COUNT([EmployeeID]) DESC


---- 5. View the scrapped products
--SELECT pp.ProductID,
--		pp.[Name] AS 'Product name',
--		SUM(wo.[ScrappedQty]) as 'Total',
--		COUNT(DISTINCT wo.ScrapReasonID) AS 'Reasons'
--FROM [Production].[Product] pp JOIN
--[Production].[WorkOrder] wo ON pp.ProductID = wo.ProductID JOIN
--[Production].[ScrapReason] sr ON wo.ScrapReasonID = sr.ScrapReasonID
--GROUP BY pp.Name, pp.ProductID
--ORDER BY SUM(wo.[ScrappedQty]) DESC


---- 6. View the product's quantity by Location
--SELECT pl.[Name],
--       SUM([Quantity]) AS 'Total quantity'
--FROM [AdventureWorks2019].[Production].[Location] pl JOIN
--[Production].[ProductInventory] pnv ON pl.LocationID = pnv.LocationID
--GROUP BY pl.[Name]


---- 7. View all the job candidates who started job as a Sales Person

--SELECT  CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS 'Full name',
--		pp.Title,
--		pp.PersonType,
--		sp.SalesYTD
--FROM [Person].[Person] pp JOIN
--[HumanResources].[JobCandidate] jc ON jc.BusinessEntityID = pp.BusinessEntityID JOIN
--[Sales].[SalesPerson] sp ON jc.BusinessEntityID = sp.BusinessEntityID


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

