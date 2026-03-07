CREATE DATABASE CustomerActivity;

USE CustomerActivity;

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL
);

CREATE TABLE Orders(
OrderID INT PRIMARY KEY,
CustomerID INT NOT NULL,
OrderDate DATE NOT NULL,
FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems(
OrderItemID INT PRIMARY KEY,
OrderID INT NOT NULL,
Quantity INT NOT NULL,
ListPrice INT NOT NULL CHECK(ListPrice > 0),
Discount DECIMAL(4,2),
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

INSERT INTO Customers (CustomerID, FirstName, LastName)
VALUES
(1, 'John', 'Smith'),
(2, 'Sara', 'Khan'),
(3, 'David', 'Lee'),
(4, 'Anita', 'Sharma'),
(5, 'Michael', 'Brown');

INSERT INTO Orders (OrderID, CustomerID, OrderDate)
VALUES
(101, 1, '2024-01-10'),
(102, 1, '2024-02-15'),
(103, 2, '2024-03-05'),
(104, 3, '2024-04-01'),
(105, 4, '2024-04-10');

INSERT INTO OrderItems (OrderItemID, OrderID, Quantity, ListPrice, Discount)
VALUES
(1, 101, 2, 2000, 0.10),
(2, 101, 1, 3000, 0.05),
(3, 102, 3, 1500, 0.00),
(4, 103, 5, 1000, 0.10),
(5, 104, 1, 8000, 0.20),
(6, 105, 4, 1200, 0.05);


SELECT C.FirstName+' '+C.LastName AS CustomerName,SUM(Quantity * ListPrice * (1 - Discount)) AS TotalValue
FROM Customers C
JOIN  Orders O
ON C.CustomerID=O.CustomerID
JOIN OrderItems OI
ON O.OrderID=OI.OrderID
GROUP BY FirstName,LastName;


SELECT C.FirstName+' '+C.LastName AS CustomerName,SUM(Quantity * ListPrice * (1 - Discount)) AS TotalValue,
CASE
WHEN SUM(Quantity * ListPrice * (1 - Discount)) > 10000 THEN 'Premium'
WHEN SUM(Quantity * ListPrice * (1 - Discount)) BETWEEN 5000 AND 10000 THEN 'Regular'
ELSE 'Basic'
END AS CustomerType
FROM Customers C
JOIN  Orders O
ON C.CustomerID=O.CustomerID
JOIN OrderItems OI
ON O.OrderID=OI.OrderID
GROUP BY FirstName,LastName;


SELECT C.FirstName+' '+C.LastName AS CustomerName,SUM(Quantity * ListPrice * (1 - Discount)) AS TotalValue,
CASE
WHEN SUM(Quantity * ListPrice * (1 - Discount)) > 10000 THEN 'Premium'
WHEN SUM(Quantity * ListPrice * (1 - Discount)) BETWEEN 5000 AND 10000 THEN 'Regular'
ELSE 'Basic'
END AS CustomerType
FROM Customers C
JOIN  Orders O
ON C.CustomerID=O.CustomerID
JOIN OrderItems OI
ON O.OrderID=OI.OrderID
GROUP BY FirstName,LastName

UNION

SELECT 
C.FirstName + ' ' + C.LastName AS CustomerName,
0 AS TotalValue,
'Basic' AS CustomerType
FROM Customers C
LEFT JOIN Orders O
ON C.CustomerID = O.CustomerID
WHERE O.CustomerID IS NULL;

