CREATE DATABASE ProductAnalysis;

USE ProductAnalysis;

CREATE TABLE Categories(
CategoryID INT PRIMARY KEY,
CategoryName VARCHAR(50) NOT NULL
);

CREATE TABLE Products(
ProductID INT PRIMARY KEY,
ProductName VARCHAR(50) NOT NULL,
CategoryID INT NOT NULL FOREIGN KEY REFERENCES Categories(CategoryID),
ModelYear SMALLINT NOT NULL,
ListPrice INT NOT NULL CHECK(ListPrice > 0)
);

INSERT INTO Categories VALUES
(1,'Bikes'),
(2,'Accessories'),
(3,'Clothing');

INSERT INTO Products VALUES
(101,'Mountain Bike',1,2022,800),
(102,'Road Bike',1,2023,1200),
(103,'Electric Bike',1,2024,2000),
(104,'Helmet',2,2022,150),
(105,'Gloves',2,2023,200),
(106,'Cycling Shoes',3,2024,500),
(107,'Jersey',3,2023,350);

SELECT * FROM Categories;

SELECT * FROM Products;

SELECT 
p.ProductName + ' (' + CAST(p.ModelYear AS VARCHAR) + ')' AS ProductDetails,
p.ModelYear,
p.ListPrice,
p.ListPrice -
(
    SELECT AVG(ListPrice)
    FROM Products
    WHERE CategoryID = p.CategoryID
) AS PriceDifference
FROM Products p
WHERE p.ListPrice >
(
    SELECT AVG(ListPrice)
    FROM Products
    WHERE CategoryID = p.CategoryID
)
ORDER BY p.ProductName;