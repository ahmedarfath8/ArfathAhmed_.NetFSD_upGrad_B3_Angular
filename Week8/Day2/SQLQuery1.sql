CREATE database StudentManagamentDB;

USE StudentManagamentDB;

CREATE TABLE Courses (
    CourseId INT PRIMARY KEY IDENTITY(1,1),
    CourseName NVARCHAR(100) NOT NULL
);

CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    StudentName NVARCHAR(100) NOT NULL,
    CourseId INT NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);

INSERT INTO Courses (CourseName)
VALUES 
('Computer Science'),
('Mechanical'),
('Electronics');

INSERT INTO Students (StudentName, CourseId)
VALUES 
('Arun', 1),
('Divya', 1),
('Karthik', 2),
('Meena', 3);

SELECT * FROM Courses;
SELECT * FROM Students; 

SELECT s.StudentId,s.StudentName,s.CourseId,c.CourseId AS CourseId,c.CourseName
FROM Students s
INNER JOIN Courses c 
ON s.CourseId = c.CourseId;

SELECT c.CourseId,c.CourseName,s.StudentId,s.StudentName,s.CourseId AS StudentCourseId
FROM Courses c
LEFT JOIN Students s 
ON c.CourseId = s.CourseId;