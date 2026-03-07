SELECT DATABASEPROPERTYEX('EventDb','Collation');

CREATE DATABASE EventDb;
USE EventDb;

CREATE TABLE UserInfo (
EmailId VARCHAR(50) PRIMARY KEY,
UserName VARCHAR(50) NOT NULL CHECK(LEN(UserName) BETWEEN 1 AND 50),
Role VARCHAR(20) NOT NULL CHECK (Role in ('Admin','Participant')),
Password VARCHAR(20) NOT NULL CHECK(LEN(password) BETWEEN 6 AND 20)
);

CREATE TABLE EventDetails (
EventId INT IDENTITY(1,1) PRIMARY KEY ,
EventName VARCHAR(50) NOT NULL CHECK(LEN(EventName) BETWEEN 1 AND 50),
EventCategory VARCHAR(50) NOT NULL CHECK(LEN(EventCategory) BETWEEN 1 AND 50),
EventDate DATETIME NOT NULL,
Description VARCHAR(100),
Status VARCHAR(15) NOT NULL CHECK(Status in ('Active','In-Active'))
);

CREATE TABLE SpeakersDetails(
SpeakerId INT IDENTITY(1,1) PRIMARY KEY ,
SpeakerName VARCHAR(50) NOT NULL CHECK(LEN(SpeakerName) BETWEEN 1 AND 50)
);

CREATE TABLE SessionInfo(
SessionId INT IDENTITY(1,1) PRIMARY KEY ,
EventId INT NOT NULL,
SessionTitle VARCHAR(50) NOT NULL CHECK(LEN(SessionTitle) BETWEEN 1 AND 50),
SpeakerId INT NOT NULL,
Description VARCHAR(100),
SessionStart DATETIME NOT NULL,
SessionEnd DATETIME NOT NULL,
SessionUrl VARCHAR(150),
FOREIGN KEY(EventId) REFERENCES EventDetails(EventId),
FOREIGN KEY(SpeakerId) REFERENCES SpeakersDetails(SpeakerId)
);

CREATE TABLE ParticipantEventDetails(
Id INT IDENTITY(1,1) PRIMARY KEY ,
ParticipantEmailId VARCHAR(50) NOT NULL FOREIGN KEY REFERENCES UserInfo(EmailId),
EventId INT NOT NULL FOREIGN KEY REFERENCES EventDetails(EventId),
SessionId INT NOT NULL FOREIGN KEY REFERENCES SessionInfo(SessionId),
IsAttended BIT NOT NULL CHECK(IsAttended=0 OR IsAttended=1)
);

INSERT INTO UserInfo 
(EmailId,UserName,Role,Password)
VALUES 
('arfath@gmail.com','arfath','Admin','arfath123'),
('ahmed@gmail.com','ahmed','Participant','ahmed123'),
('john@gmail.com','john','Participant','john123');

INSERT INTO EventDetails
(EventName, EventCategory, EventDate, Description, Status)
VALUES
('Tech Innovators Summit', 'Technology', '2026-06-15 10:00:00', 'Annual technology innovation conference', 'Active'),
('Business Growth Expo', 'Business', '2026-07-20 09:30:00', 'Entrepreneurship and startup networking event', 'Active'),
('AI & Data Science Workshop', 'Education', '2026-08-05 11:00:00', 'Hands-on workshop on AI and Data Science', 'In-Active');

INSERT INTO SpeakersDetails
(SpeakerName)
VALUES
('Dr. Rajesh Kumar'),
('Anita Sharma'),
('Michael Johnson');

INSERT INTO SessionInfo
(EventId, SessionTitle, SpeakerId, Description, SessionStart, SessionEnd, SessionUrl)
VALUES
(1, 'Future of AI', 1, 'Discussion on upcoming AI trends','2026-06-15 10:00:00','2026-06-15 11:30:00','https://event.com/ai-session'),
(2, 'Startup Funding 101', 2, 'Guide to raising venture capital','2026-07-20 09:30:00', '2026-07-20 10:45:00','https://event.com/startup-session'),
(3, 'Hands-on Machine Learning', 3, 'Practical ML implementation workshop','2026-08-05 11:00:00', '2026-08-05 12:30:00','https://event.com/ml-session');

INSERT INTO ParticipantEventDetails
(ParticipantEmailId, EventId, SessionId, IsAttended)
VALUES
('arfath@gmail.com', 1, 1, 1),
('ahmed@gmail.com', 2, 2, 0),
('john@gmail.com', 3, 3, 1);

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE';

SELECT * FROM UserInfo;
SELECT * FROM EventDetails;
SELECT * FROM SpeakersDetails;
SELECT * FROM SessionInfo;
SELECT * FROM ParticipantEventDetails;