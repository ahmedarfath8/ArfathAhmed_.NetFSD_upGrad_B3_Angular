CREATE DATABASE ProductDB;

USE ProductDB;

CREATE TABLE Products(
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    Category VARCHAR(50) NOT NULL,
    Price DECIMAL(10,2) NOT NULL CHECK (Price > 0),
    Stock INT NOT NULL CHECK (Stock >= 0)
);

--Insert
CREATE PROCEDURE sp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2),
    @Stock INT
AS
BEGIN
    INSERT INTO Products (ProductName, Category, Price, Stock)
    VALUES (@ProductName, @Category, @Price, @Stock);
END;

--View
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END;


--Update
CREATE PROCEDURE sp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2),
    @Stock INT
AS
BEGIN
    UPDATE Products
    SET 
        ProductName = @ProductName,
        Category = @Category,
        Price = @Price,
        Stock = @Stock
    WHERE ProductId = @ProductId;
END;


--Delete
CREATE PROCEDURE sp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products
    WHERE ProductId = @ProductId;
END;



EXEC sp_InsertProduct 'sample', 'sampleEntry', 10000, 10;
EXEC sp_GetAllProducts;
EXEC sp_UpdateProduct 1,'sampleUpdate', 'sampleEntryUpdate', 20000, 20;
EXEC sp_DeleteProduct 1;

truncate table Products;