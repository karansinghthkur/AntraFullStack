--1.      List all cities that have both Employees and Customers.
select distinct e.city
from employees e
where e.city IN (select c.city from Customers c)

--2.      List all cities that have Customers but no Employee.

--a.      Use sub-query
select distinct c.city
from Customers c
where c.city NOT IN (select e.city from Employees e)

--b.      Do not use sub-query
SELECT DISTINCT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL;


--3. List all products and their total order quantities throughout all orders.

select p.ProductName, SUM(od.Quantity) as TotalQuantity
from Products p 
join [order Details] od on p.ProductID=od.ProductId
group by p.ProductName
order by TotalQuantity desc

--4. List all Customer Cities and total products ordered by that city.
select c.City,SUM(od.Quantity) as TotalProducts
from customers c
join orders o on c.CustomerID=o.CustomerID
join [order Details] od on o.OrderID=od.OrderId
join Products p on od.ProductID=p.ProductId
group by  c.City
order by TotalProducts desc

--5. List all Customer Cities that have at least two customers.
select c.City, Count(c.CustomerID) As TotalCustomers
from Customers c 
group by c.City 
having Count(c.CustomerID) >=2
order  by TotalCustomers desc

--6. List all Customer Cities that have ordered at least two different kinds of products.
select c.City,count(distinct p.ProductId) as UniqueProducts
from customers c
join orders o on c.CustomerID=o.CustomerID
join [order Details] od on o.OrderID=od.OrderId
join Products p on od.ProductID=p.ProductId
group by  c.City
having count( distinct p.ProductId)>=2

--7 List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
select distinct c.ContactName
from Customers c 
join Orders o on c.CustomerID=o.CustomerId
where c.City<>o.ShipCity

--8  List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
select TOP 5 p.ProductName, AVG(p.UnitPrice) as  AveragePrice, c.city
from products p 
join [order Details] od on p.ProductID=od.ProductID
join orders o on od.OrderID=o.OrderID 
join customers c on o.CustomerID=c.CustomerID
Group by  p.ProductName, c.city
order by SUM(od.Quantity)  desc

--9.      List all cities that have never ordered something but we have employees there.

   --a.      Use sub-query
    select distinct  e.City
    from employees e
    where  e.City NOT IN(select distinct c.City 
        from Customers c 
        left join Orders o on c.CustomerId=o.CustomerId
       )

   --b.      Do not use sub-query
    SELECT DISTINCT e.City
    FROM Employees e
    LEFT JOIN Customers c ON e.City = c.City
    LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
    WHERE o.CustomerID IS NULL;

--10 List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
SELECT TOP 1 e.City 
FROM Employees e
JOIN Orders o ON e.EmployeeID = o.EmployeeID
JOIN (
    -- Subquery: Find the city with the highest total quantity of products ordered
    SELECT TOP 1 c.City 
    FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY c.City
    ORDER BY SUM(od.Quantity) DESC
) AS top_ordered_city ON e.City = top_ordered_city.City
GROUP BY e.City
ORDER BY COUNT(o.OrderID) DESC;

--11. How do you remove the duplicates record of a table?
--Using DELETE with ROW_NUMBER() we can proceed  
--or one more method is by Using CREATE TABLE AS SELECT DISTINCT (If Allowed)

