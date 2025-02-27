--Assignment

--1.      How many products can you find in the Production.Product table?
select Count(productID) AS TotalProducts
FROM Production.Product

--2.Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(*) AS ProductCount
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL;

--3.How many Products reside in each SubCategory? Write a query to display the results with the following titles.
SELECT 
    ProductSubcategoryID, 
    COUNT(*) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID;

--4.      How many products that do not have a product subcategory.

SELECT 
    COUNT(*) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

--5.      Write a query to list the sum of products quantity in the Production.ProductInventory table.

select SUM(Quantity) as TotalQuantity
from Production.ProductInventory

--6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
select ProductId, SUM(Quantity) as TheSum
from Production.ProductInventory where LocationID=40 
Group BY ProductId having SUM(Quantity)<100

--7.    Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
select Shelf,ProductId, SUM(Quantity) as TheSum
from Production.ProductInventory where LocationID=40 
Group BY ProductId,Shelf having SUM(Quantity)<100

--8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

select AVG(Quantity) as AVERAGE
from Production.ProductInventory where LocationID=10 


--9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
select ProductId, Shelf, AVG(Quantity) as TheAvg
from Production.ProductInventory
Group BY ProductId,Shelf

--10 Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

select ProductId, Shelf, AVG(Quantity) as TheAvg
from Production.ProductInventory where Shelf NOT IN ('N/A')
Group BY ProductId,Shelf 

--11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.

select Color, Class, Count(ProductID) As TheCount, AVG(ListPrice) As AvgPrice
from Production.product where Color IS NOT NULL and Class IS NOT NULL
Group By Color, Class

--12. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c
JOIN Person.StateProvince s 
ON c.CountryRegionCode = s.CountryRegionCode;

--13. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
SELECT c.Name AS Country, s.Name AS Province
FROM Person.CountryRegion c 
JOIN Person.StateProvince s 
ON c.CountryRegionCode = s.CountryRegionCode
where c.Name IN('Germany', 'Canada')

--14.List all Products that has been sold at least once in last 27 years.
select p.ProductName, o.OrderDate
from Products p 
Join [Order Details] od on p.ProductId=od.ProductId Join Orders o on od.OrderID=o.OrderId
where o.OrderDate >= DATEADD(YEAR, -27, GETDATE());

--15.List top 5 locations (Zip Code) where the products sold most.
select TOP 5 o.ShipPostalCode As ZipCode, Count(od.ProductId) as TotalSold
from Products p 
Join [Order Details] od on p.ProductId=od.ProductId Join Orders o on od.OrderID=o.OrderId where o.ShipPostalCode IS NOT NULL
Group By o.ShipPostalCode
order by TotalSold desc;
--16 List top 5 locations (Zip Code) where the products sold most in last 27 years.
select TOP 5 o.ShipPostalCode As ZipCode, Count(od.ProductId) as TotalSold
from Products p 
Join [Order Details] od on p.ProductId=od.ProductId Join Orders o on od.OrderID=o.OrderId where o.ShipPostalCode IS NOT NULL and  o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
Group By o.ShipPostalCode
order by TotalSold desc;


-- 17 List all city names and number of customers in that city. 
SELECT City, COUNT(CustomerID) AS NumberOfCustomers
FROM Customers
GROUP BY City
ORDER BY NumberOfCustomers DESC;

--18.  List city names which have more than 2 customers, and number of customers in that city
SELECT City, COUNT(CustomerID) AS NumberOfCustomers
FROM Customers
GROUP BY City
having COUNT(CustomerID)>2
ORDER BY NumberOfCustomers DESC;

-- 19 List the names of customers who placed orders after 1/1/98 with order date.
SELECT c.ContactName As CustomerName, o.OrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'
ORDER BY o.OrderDate;

--20 List the names of all customers with most recent order dates
SELECT c.ContactName As CustomerName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName
ORDER BY MostRecentOrderDate DESC;

--21 Display the names of all customers  along with the  count of products they bought
SELECT c.ContactName, COUNT(od.ProductID) AS TotalProductsBought
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName
ORDER BY TotalProductsBought DESC;


--22 Display the customer ids who bought more than 100 Products with count of products.
SELECT c.CustomerID, COUNT(od.ProductID) AS TotalProductsBought
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID
HAVING COUNT(od.ProductID) > 100
ORDER BY TotalProductsBought DESC;


-- 23  List all of the possible ways that suppliers can ship their products. Display the results as below
SELECT s.CompanyName AS SupplierCompanyName, sh.CompanyName AS ShippingCompanyName
FROM Suppliers s
JOIN Products p ON s.SupplierID = p.SupplierID
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderID = o.OrderID
JOIN Shippers sh ON o.ShipVia = sh.ShipperID
GROUP BY s.CompanyName, sh.CompanyName
ORDER BY s.CompanyName, sh.CompanyName;

--24 Display the products order each day. Show Order date and Product Name.

select p.ProductName as Products,o.orderDate
from products p 
join [Order Details] od on p.productID=od.ProductId
join orders o on od.orderid=o.orderid
order by o.orderDate,p.ProductName

--25  Displays pairs of employees who have the same job title.
select e.EmployeeID AS Employee1_ID, e.FirstName+' '+e.LastName AS Employee1_Name,
       f.EmployeeID AS Employee2_ID, f.FirstName+' '+f.LastName AS Employee2_Name,
       e.Title
from employees e 
join employees f
on e.Title=f.Title
    and e.EmployeeID<f.EmployeeID
order by e.Title, e.EmployeeID,f.employeeID


--26 Display all the Managers who have more than 2 employees reporting to them.
SELECT m.FirstName + ' ' + m.LastName AS ManagerName, 
       COUNT(e.EmployeeID) AS EmployeeCount
FROM Employees e
JOIN Employees m ON e.ReportsTo = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.EmployeeID) > 2
ORDER BY EmployeeCount DESC;



--27.  Display the customers and suppliers by city. The results should have the following columns
SELECT City, CompanyName AS Name, ContactName, 'Customer' AS Type
FROM Customers

UNION 

SELECT City, CompanyName AS Name, ContactName, 'Supplier' AS Type
FROM Suppliers

ORDER BY City, Type;