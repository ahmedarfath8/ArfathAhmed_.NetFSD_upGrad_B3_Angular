CREATE DATABASE Problem3;

USE Problem3;

CREATE TABLE Stores(
StoreID INT NOT NULL PRIMARY KEY,
StoreName VARCHAR(50) NOT NULL
);

CREATE TABLE Orders(
OrderID INT NOT NULL PRIMARY KEY,
StoreID INT NOT NULL FOREIGN KEY REFERENCES Stores(StoreID),
OrderStatus INT NOT NULL CHECK(OrderStatus=1 OR OrderStatus=4)
);

CREATE TABLE OrderItem(
OrderID INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderID),
Quantity TINYINT NOT NULL,
ListPrice INT NOT NULL CHECK(ListPrice>0),
Discount DECIMAL(4,2),
PRIMARY KEY (OrderID, ListPrice)
);

INSERT INTO Stores (StoreID, StoreName)
VALUES
(1, 'Downtown Store'),
(2, 'City Mall Store'),
(3, 'Airport Store');

INSERT INTO Orders (OrderID, StoreID, OrderStatus)
VALUES
(101, 1, 4),
(102, 1, 1),
(103, 2, 4),
(104, 3, 4),
(105, 2, 1);

INSERT INTO OrderItem (OrderID, Quantity, ListPrice, Discount)
VALUES
(101, 2, 1000, 0.10),
(101, 1, 500, 0.05),
(102, 3, 300, 0.00),
(103, 1, 1500, 0.15),
(104, 2, 700, 0.10),
(105, 1, 2000, 0.20);

SELECT S.StoreName, SUM(Quantity * ListPrice * (1 - Discount)) AS Total
FROM OrderItem Oi
INNER JOIN Orders O
ON Oi.OrderID = O.OrderID
INNER JOIN Stores S
ON O.StoreID = S.StoreID
WHERE OrderStatus=4
GROUP BY StoreName
ORDER BY Total DESC;
