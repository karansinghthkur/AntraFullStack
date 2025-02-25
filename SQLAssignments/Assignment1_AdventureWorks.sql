USE AdventureWorks2019
GO
--1.query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, with no filter.

SELECT ProductID, Name, Color, ListPrice
FROM Production.Product;

--2.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, excludes the rows that ListPrice is 0.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product where ListPrice !=0;


--3.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are NULL for the Color column.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product where Color IS NULL;

--4.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the Color column.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product where Color IS NOT NULL;

--5.Write a query that retrieves the columns ProductID, Name, Color and ListPrice from the Production.Product table, the rows that are not NULL for the column Color, and the column ListPrice has a value greater than zero.
SELECT ProductID, Name, Color, ListPrice
FROM Production.Product where Color IS NOT NULL and ListPrice>0;

--6.Write a query that concatenates the columns Name and Color from the Production.Product table by excluding the rows that are null for color.
SELECT Name + ' ' + Color AS ProductDescription
FROM Production.Product
WHERE Color IS NOT NULL;

--7.Write a query that generates the following result set  from Production.Product:
SELECT 'NAME: ' + Name + '  --  COLOR: ' + Color AS ProductDetails
FROM Production.Product
WHERE (Name IN ('LL Crankarm', 'ML Crankarm', 'HL Crankarm', 'Chainring Bolts', 'Chainring Nut', 'Chainring'))
  AND (Color IN ('Black', 'Silver'));

--8.Write a query to retrieve the to the columns ProductID and Name from the Production.Product table filtered by ProductID from 400 to 500
SELECT ProductID, Name
FROM Production.Product WHERE ProductID BETWEEN 400 AND 500

--9.Write a query to retrieve the to the columns  ProductID, Name and color from the Production.Product table restricted to the colors black and blue
SELECT ProductID, Name, Color
FROM Production.Product WHERE Color IN('Black','Blue')

--10.Write a query to get a result set on products that begins with the letter S. 
select ProductID, Name, Color
from Production.Product where  Name LIKE 'S%'

--11.Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. 
SELECT Name, ListPrice
FROM Production.Product
ORDER BY Name


--12. Write a query that retrieves the columns Name and ListPrice from the Production.Product table. Your result set should look something like the following. Order the result set by the Name column. The products name should start with either 'A' or 'S'
Select Name, ListPrice
From Production.Product
where Name LIKE '[A,S]%'
Order BY Name

-- 13.Write a query so you retrieve rows that have a Name that begins with the letters SPO, but is then not followed by the letter K. After this zero or more letters can exists. Order the result set by the Name column.
Select Name, ListPrice
From Production.Product
where Name LIKE 'SPO[^K]%'
Order BY Name

--14.Write a query that retrieves unique colors from the table Production.Product. Order the results  in descending  manner.
Select distinct Color
from Production.Product order by Color desc;
