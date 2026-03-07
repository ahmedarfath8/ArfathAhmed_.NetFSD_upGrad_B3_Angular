CREATE DATABASE Problem1;

USE Problem1;

CREATE TABLE customers(
CustomerID INT PRIMARY KEY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50)
);

CREATE  TABLE Orders(
OrderID INT PRIMARY KEY,
CustomerID INT FOREIGN KEY REFERENCES customers(CustomerID),
OrderDate DATE NOT NULL,
OrderStatus TINYINT NOT NULL CHECK(OrderStatus=1 OR OrderStatus=4)
);

INSERT INTO customers (CustomerID, FirstName, LastName)
VALUES
(1, 'Arfath', 'Ahmed'),
(2, 'John', 'Smith'),
(3, 'Sara', 'Khan'),
(4, 'David', 'Lee'),
(5, 'Anita', 'Sharma');

INSERT INTO Orders (OrderID, CustomerID, OrderDate, OrderStatus)
VALUES
(101, 1, '2026-03-01', 1),
(102, 2, '2026-03-03', 4),
(103, 3, '2026-03-05', 1),
(104, 1, '2026-03-07', 4),
(105, 4, '2026-03-09', 1);

SELECT FirstName, LastName, OrderID, OrderDate, OrderStatus
FROM customers
INNER JOIN Orders
ON customers.CustomerID = Orders.CustomerID
WHERE (OrderStatus = 1 OR OrderStatus = 4)
ORDER BY OrderDate DESC;