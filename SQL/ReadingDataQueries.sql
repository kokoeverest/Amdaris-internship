USE AdventureWorks2019;

--All the following requirements are based on the Adventure Works database

--1. From the Person.Person table write a query in SQL to return all rows and a subset of the columns 
--(FirstName, LastName, businessentityid) from the person table in the AdventureWorks database. 
--The third column heading is renamed to Employee_id. Arranged the output in ascending order by lastname.

--SELECT FirstName, LastName, BusinessEntityID as Employee_Id FROM Person.Person;

--2. From the Person.PersonPhone table write a query in SQL to find the persons whose last name starts with letter 'L'. 
--Return BusinessEntityID, FirstName, LastName, and PhoneNumber. Sort the result on lastname and firstname.

--SELECT Person.Person.BusinessEntityID as Employee_Id, Person.Person.FirstName, Person.Person.LastName, Person.PersonPhone.PhoneNumber
--FROM Person.PersonPhone JOIN
--     Person.Person ON Person.PersonPhone.BusinessEntityID = Person.Person.BusinessEntityID
--WHERE Person.Person.LastName LIKE 'L%'
--ORDER BY Person.Person.LastName, Person.Person.FirstName;


--3.  From the following tables: Sales.SalesPerson, Person.Person, Person.Address
--Write a query in SQL to retrieve the salesperson for each PostalCode who belongs to a territory and SalesYTD is not zero. 
--Return row numbers of each group of PostalCode, last name, salesytd, postalcode column. Sort the salesytd of each postalcode group in descending order. 
--Shorts the postalcode in ascending order.

--SELECT ROW_NUMBER() OVER(PARTITION BY a.PostalCode ORDER BY s.SalesYTD DESC) AS RowNumber, p.LastName, s.SalesYTD, a.PostalCode
--FROM [Sales].[SalesPerson] s 
--JOIN Person.Person p ON s.BusinessEntityID = p.BusinessEntityID 
--JOIN Person.Address a ON p.BusinessEntityID = a.AddressID
--WHERE s.TerritoryID IS NOT NULL 
--AND s.SalesYTD != 0
--ORDER BY a.PostalCode ASC, s.SalesYTD DESC;

SELECT COUNT(Person.Address.PostalCode) AS [Row Number], Person.Address.PostalCode, Person.Person.LastName, Sales.SalesPerson.SalesYTD
FROM Sales.SalesPerson INNER JOIN
    Person.Person ON Sales.SalesPerson.BusinessEntityID = Person.Person.BusinessEntityID CROSS JOIN
    Person.Address
WHERE (Sales.SalesPerson.TerritoryID IS NOT NULL) AND (Sales.SalesPerson.SalesYTD > 0)
GROUP BY Person.Address.PostalCode, Person.Person.LastName, Sales.SalesPerson.SalesYTD
ORDER BY Person.Address.PostalCode, Sales.SalesPerson.SalesYTD DESC


--4. From the following table: Sales.SalesOrderDetail 
--Write a query in SQL to retrieve the total cost of each salesorderID that exceeds 100000. Return SalesOrderID, total cost.

--SELECT [SalesOrderID], SUM(LineTotal) AS [Total cost]
--FROM [Sales].[SalesOrderDetail]
--GROUP BY SalesOrderID
--HAVING SUM(LineTotal) > 100000
