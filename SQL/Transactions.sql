USE AdventureWorks2019 ;

----Requirements
----Starting again from the AdventureWorks database:

----Perform inserts, updates and deletes that require several operations to be part of a transaction. 

----Write 8 such transactions. 

----Make sure that the operations you perform make sense from a business perspective


---- 1. Insert a new description for a product and return the last row id 

--BEGIN TRY
--	BEGIN TRANSACTION;

--	INSERT INTO [Production].[ProductDescription] ([Description], [rowguid], [ModifiedDate]) 
--	VALUES ('xxx', '650ED5F9-243D-4E4C-B873-50F2DABBE3D3', GETDATE());
--	PRINT 'Success';
--	COMMIT TRANSACTION;
--	SELECT SCOPE_IDENTITY();
--END TRY

--BEGIN CATCH
--	ROLLBACK TRANSACTION;
--	PRINT 'Transaction failed: ' + ERROR_MESSAGE();
--END CATCH

	

---- 2. Delete a product description by providing an id
--BEGIN TRY
--	BEGIN TRANSACTION;
--	DELETE FROM [Production].[ProductDescription] WHERE ProductDescriptionID > 2015;
--	PRINT 'Success';
--	COMMIT TRANSACTION;
--END TRY

--BEGIN CATCH
--	ROLLBACK TRANSACTION;
--	PRINT ERROR_MESSAGE();
--END CATCH

---- A simple insert query
--BEGIN TRY
--	BEGIN TRANSACTION;
--	INSERT INTO [Sales].[SalesPerson] ([BusinessEntityID], [TerritoryID], [SalesQuota], [Bonus], [CommissionPct], [SalesYTD], [SalesLastYear], [rowguid], [ModifiedDate])
--	VALUES (NULL, NULL, NULL, 0.0, 0, 0, 0, 'A0CE0-0A9SD-DNSJA-KAJSUDN2', GETDATE());
--	COMMIT TRANSACTION;
--END TRY

--BEGIN CATCH
--	ROLLBACK TRANSACTION;
--	PRINT 'Transaction failed: ' + ERROR_MESSAGE();
--END CATCH

---- 3.  Insert a business entity address
--BEGIN TRY
--	BEGIN TRANSACTION;
--	INSERT INTO [Person].[Address]
--           ([AddressLine1]
--           ,[AddressLine2]
--           ,[City]
--           ,[StateProvinceID]
--           ,[PostalCode]
--           ,[SpatialLocation]
--           ,[rowguid]
--           ,[ModifiedDate])
--     VALUES
--           ('<AddressLine1, nvarchar(60),>'
--           ,'<AddressLine2, nvarchar(60),>'
--           ,'<City,         nvarchar(30),>'
--           ,'<StateProvinceID,       int,>'
--           ,'<PostalCode,   nvarchar(15),>'
--           ,'<SpatialLocation, geography,>'
--           ,'<rowguid,  uniqueidentifier,>'
--           ,GETDATE());

--	DECLARE @LastAddressID INT;
--	set @LastAddressID = SCOPE_IDENTITY();
	
--	INSERT INTO [Person].[BusinessEntityAddress]
--			([BusinessEntityID]
--			,[AddressID]
--			,[AddressTypeID]
--			,[rowguid]
--			,[ModifiedDate])
--	VALUES
--		  (111111111, @LastAddressID, 222222, '<rowguid,  uniqueidentifier,>', GETDATE());

--	COMMIT TRANSACTION;
--END TRY

--BEGIN CATCH
--	ROLLBACK TRANSACTION;
--	PRINT 'Transaction failed: ' + ERROR_MESSAGE();
--END CATCH


-- 4. Update the salesperson SalesLastYear 

--BEGIN TRY
--	BEGIN TRANSACTION;
--	DECLARE @LastYearSales money;
--	SET @LastYearSales = (SELECT SUM(sod.[LineTotal]) FROM [Sales].[SalesOrderDetail] AS sod JOIN
--							[Sales].[SalesOrderHeader] AS soh ON soh.SalesOrderID = sod.SalesOrderID
--							WHERE soh.SalesPersonID = 123456 AND YEAR(soh.OrderDate) = 2013);

--	UPDATE [Sales].[SalesPerson]
--	SET SalesLastYear = @LastYearSales 
--	WHERE BusinessEntityID = 123456;

--	COMMIT TRANSACTION;
--END TRY

--BEGIN CATCH
--	ROLLBACK TRANSACTION;
--	PRINT 'Transaction failed: ' + ERROR_MESSAGE();
--END CATCH

-- 5. Create a product and add a review to it in one transaction
--BEGIN TRY
--	BEGIN TRANSACTION;

--	INSERT INTO [Production].[Product]
--			   ([Name]
--			   ,[ProductNumber]
--			   ,[MakeFlag]
--			   ,[FinishedGoodsFlag]
--			   ,[Color]
--			   ,[SafetyStockLevel]
--			   ,[ReorderPoint]
--			   ,[StandardCost]
--			   ,[ListPrice]
--			   ,[Size]
--			   ,[SizeUnitMeasureCode]
--			   ,[WeightUnitMeasureCode]
--			   ,[Weight]
--			   ,[DaysToManufacture]
--			   ,[ProductLine]
--			   ,[Class]
--			   ,[Style]
--			   ,[ProductSubcategoryID]
--			   ,[ProductModelID]
--			   ,[SellStartDate]
--			   ,[SellEndDate]
--			   ,[DiscontinuedDate]
--			   ,[rowguid]
--			   ,[ModifiedDate])
--		 VALUES
--			   ('<Name, [dbo].[Name],>'
--			   ,'<ProductNumber, nvarchar(25),>'
--			   ,'<MakeFlag, [dbo].[Flag],>'
--			   ,'<FinishedGoodsFlag, [dbo].[Flag],>'
--			   ,'<Color, nvarchar(15),>'
--			   ,'<SafetyStockLevel, smallint,>'
--			   ,'<ReorderPoint, smallint,>'
--			   ,'<StandardCost, money,>'
--			   ,'<ListPrice, money,>'
--			   ,'<Size, nvarchar(5),>'
--			   ,'<SizeUnitMeasureCode, nchar(3),>'
--			   ,'<WeightUnitMeasureCode, nchar(3),>'
--			   ,'<Weight, decimal(8,2),>'
--			   ,'<DaysToManufacture, int,>'
--			   ,'<ProductLine, nchar(2),>'
--			   ,'<Class, nchar(2),>'
--			   ,'<Style, nchar(2),>'
--			   ,'<ProductSubcategoryID, int,>'
--			   ,'<ProductModelID, int,>'
--			   ,'<SellStartDate, datetime,>'
--			   ,'<SellEndDate, datetime,>'
--			   ,'<DiscontinuedDate, datetime,>'
--			   ,'<rowguid, uniqueidentifier,>'
--			   ,'<ModifiedDate, datetime,>')
	
--	DECLARE @LastProductID INT;
--	set @LastProductID = SCOPE_IDENTITY();

--	INSERT INTO [Production].[ProductReview]
--			   ([ProductID]
--			   ,[ReviewerName]
--			   ,[ReviewDate]
--			   ,[EmailAddress]
--			   ,[Rating]
--			   ,[Comments]
--			   ,[ModifiedDate])
--		 VALUES
--			   (@LastProductId
--			   ,'<ReviewerName, [dbo].[Name],>'
--			   ,'<ReviewDate, datetime,>'
--			   ,'<EmailAddress, nvarchar(50),>'
--			   ,'<Rating, int,>'
--			   ,'<Comments, nvarchar(3850),>'
--			   ,'<ModifiedDate, datetime,>')
	
--	COMMIT TRANSACTION
--END TRY

--BEGIN CATCH
--	PRINT 'Transaction failed: ' + ERROR_MESSAGE();
--	ROLLBACK TRANSACTION
--END CATCH


-- 6. Add new purchase 
--begin try
--	begin transaction
	
--	INSERT INTO [Purchasing].[PurchaseOrderHeader]
--			   ([RevisionNumber]
--			   ,[Status]
--			   ,[EmployeeID]
--			   ,[VendorID]
--			   ,[ShipMethodID]
--			   ,[OrderDate]
--			   ,[ShipDate]
--			   ,[SubTotal]
--			   ,[TaxAmt]
--			   ,[Freight]
--			   ,[ModifiedDate])
--		 VALUES
--			   (<RevisionNumber, tinyint,>
--			   ,<Status, tinyint,>
--			   ,<EmployeeID, int,>
--			   ,<VendorID, int,>
--			   ,<ShipMethodID, int,>
--			   ,<OrderDate, datetime,>
--			   ,<ShipDate, datetime,>
--			   ,<SubTotal, money,>
--			   ,<TaxAmt, money,>
--			   ,<Freight, money,>
--			   ,<ModifiedDate, datetime,>)

--		DECLARE @LastPurchaseOrderID INT;
--		set @LastPurchaseOrderID = SCOPE_IDENTITY();
	
--INSERT INTO [Purchasing].[PurchaseOrderDetail]
--           ([PurchaseOrderID]
--           ,[DueDate]
--           ,[OrderQty]
--           ,[ProductID]
--           ,[UnitPrice]
--           ,[ReceivedQty]
--           ,[RejectedQty]
--           ,[ModifiedDate])
--     VALUES
--           (@LastPurchaseOrderID
--           ,<DueDate, datetime,>
--           ,<OrderQty, smallint,>
--           ,<ProductID, int,>
--           ,<UnitPrice, money,>
--           ,<ReceivedQty, decimal(8,2),>
--           ,<RejectedQty, decimal(8,2),>
--           ,<ModifiedDate, datetime,>)

--	commit transaction
--end try

--begin catch
--	PRINT 'Transaction failed: ' + ERROR_MESSAGE();
--	rollback transaction
--end catch

-- 7. Update the currency rate USD-EUR and recalculate the corresponding purchases 
-- according to it for a certain period of time

--begin try
--	begin transaction;
	
--	DECLARE @StartDate Datetime;
--	Set @StartDate = '2013-07-03 00:00:00.000';

--	DECLARE @EndDate Datetime;
--	Set @EndDate = '2013-09-03 00:00:00.000';

--	DECLARE @AvgRate MONEY;
--	Set @AvgRate = 0.9;

--	DECLARE @Today Datetime;
--	Set @Today = getdate();

		
--		UPDATE [Sales].[CurrencyRate]
--		   SET 
--			  [AverageRate] = @AvgRate
--			  ,[EndOfDayRate] = 0.92
--			  ,[ModifiedDate] = @Today
--		  WHERE CurrencyRateDate >= @StartDate and CurrencyRateDate <= @EndDate and ToCurrencyCode = 'EUR'; 


	
--		UPDATE [Purchasing].[PurchaseOrderHeader]
--		   SET 
--			  [SubTotal] = SubTotal * @AvgRate
--			  ,[ModifiedDate] = @Today
			
--			WHERE VendorID = 1536 and OrderDate >= @StartDate and OrderDate <= @EndDate

--	commit transaction;
--end try

--begin catch
--	PRINT 'Transaction failed: ' + ERROR_MESSAGE();
--	rollback transaction;
--end catch

-- 8. Create a new shipment method and update some purchases to be delivered by the new shipping method


begin try
	begin transaction;

	DECLARE @OrderID INT;
	Set @OrderID = 29;

	DECLARE @ShipBase MONEY;
	Set @ShipBase = 49.99;

	DECLARE @ShipRate MONEY;
	Set @ShipRate = 4.99;

	DECLARE @Today Datetime;
	Set @Today = GETDATE();

	INSERT INTO [Purchasing].[ShipMethod]
           ([Name]
           ,[ShipBase]
           ,[ShipRate]
           ,[rowguid]
           ,[ModifiedDate])
     VALUES
           ('TELEPORT'
           ,@ShipBase
           ,@ShipRate
           ,'B166019A-B134-4E76-B347-2B0490C610AC'
           ,@Today)

	DECLARE @LastShippingMethodID INT;
	set @LastShippingMethodID = SCOPE_IDENTITY();

	DECLARE @OldTotalDue money;
	set @OldTotalDue = (select [TotalDue] - [Freight] from [Purchasing].[PurchaseOrderHeader] where PurchaseOrderID = @OrderID);

	DECLARE @NewFreight money;
	set @NewFreight = (select [Freight] from [Purchasing].[PurchaseOrderHeader] where PurchaseOrderID = @OrderID);

	
	UPDATE [Purchasing].[PurchaseOrderHeader]
	   SET [ShipMethodID] = @LastShippingMethodID
		  ,[Freight] = @NewFreight
		  --,[TotalDue] = @OldTotalDue + @NewFreight
		  ,[ModifiedDate] = @Today
	 WHERE PurchaseOrderID = @OrderID

	commit transaction;
end try

begin catch
	PRINT 'Transaction failed: ' + ERROR_MESSAGE();
	rollback transaction;
end catch