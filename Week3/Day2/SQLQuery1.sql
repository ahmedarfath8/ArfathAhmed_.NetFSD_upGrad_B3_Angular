CREATE DATABASE StudentDB;
GO
USE StudentDB;
GO
CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Age INT,
    Email NVARCHAR(100)
);
INSERT INTO Students (Name, Age, Email)
VALUES 
('Arfat', 22, 'arfat@gmail.com'),
('Rahul', 23, 'rahul@gmail.com');
SELECT * FROM Students;
DROP database studentDB;
use master;