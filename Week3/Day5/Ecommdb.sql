CREATE DATABASE EcommDb;
GO

USE EcommDb;
GO

CREATE TABLE Categories(
CategoryID INT PRIMARY KEY IDENTITY(1,1),
CategoryName VARCHAR(100) NOT NULL
);

CREATE TABLE Brands(
BrandID INT PRIMARY KEY IDENTITY(1,1),
BrandName VARCHAR(100) NOT NULL
);

CREATE TABLE Products(
ProductID INT PRIMARY KEY IDENTITY(1,1),
ProductName VARCHAR(150) NOT NULL,
BrandID INT NOT NULL,
CategoryID INT NOT NULL,
ModelYear INT,
Price DECIMAL(8,2),
FOREIGN KEY (BrandID) REFERENCES Brands(BrandID),
FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(100),
LastName VARCHAR(100),
Email VARCHAR(150),
Phone VARCHAR(20),
City VARCHAR(100)
);

CREATE TABLE Stores(
StoreID INT PRIMARY KEY IDENTITY(1,1),
StoreName VARCHAR(150),
City VARCHAR(100),
Phone VARCHAR(20)
);

INSERT INTO Categories (CategoryName) VALUES
('Sedan'),
('SUV'),
('Hatchback'),
('Electric Cars'),
('Accessories');

INSERT INTO Brands (BrandName) VALUES
('Toyota'),
('Honda'),
('BMW'),
('Tesla'),
('Hyundai');

INSERT INTO Products (ProductName, BrandID, CategoryID, ModelYear, Price) VALUES
('Toyota Camry', 1, 1, 2023, 30000),
('Honda CR-V', 2, 2, 2024, 35000),
('BMW X5', 3, 2, 2023, 65000),
('Tesla Model 3', 4, 4, 2024, 45000),
('Hyundai i20', 5, 3, 2023, 20000);

INSERT INTO Customers (FirstName, LastName, Email, Phone, City) VALUES
('Rahul', 'Sharma', 'rahul.sharma@email.com', '9876543210', 'Bangalore'),
('Priya', 'Mehta', 'priya.mehta@email.com', '9876543211', 'Mumbai'),
('Arjun', 'Reddy', 'arjun.reddy@email.com', '9876543212', 'Hyderabad'),
('Sneha', 'Kapoor', 'sneha.kapoor@email.com', '9876543213', 'Delhi'),
('Vikram', 'Singh', 'vikram.singh@email.com', '9876543214', 'Bangalore');

INSERT INTO Stores (StoreName, City, Phone) VALUES
('AutoHub Bangalore', 'Bangalore', '0801234567'),
('AutoHub Mumbai', 'Mumbai', '0221234567'),
('AutoHub Delhi', 'Delhi', '0111234567'),
('AutoHub Hyderabad', 'Hyderabad', '0401234567'),
('AutoHub Chennai', 'Chennai', '0441234567');

SELECT p.ProductName,b.BrandName,c.CategoryName,p.ModelYear,p.Price
FROM Products p
JOIN Brands b ON p.BrandID = b.BrandID
JOIN Categories c ON p.CategoryID = c.CategoryID;

SELECT *
FROM Customers
WHERE City = 'Bangalore';

SELECT c.CategoryName,
COUNT(p.ProductID) AS TotalProducts
FROM Categories c
LEFT JOIN Products p 
ON c.CategoryID = p.CategoryID
GROUP BY c.CategoryName;