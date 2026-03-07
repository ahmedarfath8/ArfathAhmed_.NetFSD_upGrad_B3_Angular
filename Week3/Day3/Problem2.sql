CREATE DATABASE Problem2;

USE Problem2;

CREATE TABLE Categories(
CategoryID INT PRIMARY KEY,
CategoryName VARCHAR(50)
);

CREATE TABLE Brands(
BrandID INT PRIMARY KEY,
BrandName VARCHAR(50)
);

CREATE TABLE Products(
ProductID INT PRIMARY KEY,
ProductName VARCHAR(50) NOT NULL,
BrandID INT FOREIGN KEY REFERENCES Brands(BrandID),
CategoryID INT FOREIGN KEY REFERENCES Categories(CategoryID),
ModelYear SMALLINT CHECK(ModelYear BETWEEN 2000 AND 2026),
ListPrice INT NOT NULL CHECK(ListPrice > 0)
);

INSERT INTO Categories (CategoryID, CategoryName)
VALUES
(1, 'Bikes'),
(2, 'Accessories'),
(3, 'Clothing');

INSERT INTO Brands (BrandID, BrandName)
VALUES
(1, 'Trek'),
(2, 'Giant'),
(3, 'Specialized');

INSERT INTO Products (ProductID, ProductName, BrandID, CategoryID, ModelYear, ListPrice)
VALUES
(101, 'Mountain Bike', 1, 1, 2023, 800),
(102, 'Road Bike', 2, 1, 2024, 1200),
(103, 'Bike Helmet', 3, 2, 2022, 200),
(104, 'Cycling Gloves', 2, 3, 2024, 600),
(105, 'Electric Bike', 1, 1, 2025, 2000);

SELECT p.ProductName,b.BrandName,c.CategoryName,p.ModelYear,p.ListPrice
FROM Products p
INNER JOIN Brands b
ON p.BrandID = b.BrandID
INNER JOIN Categories c
ON p.CategoryID = c.CategoryID
WHERE p.ListPrice > 500
ORDER BY p.ListPrice ASC;

