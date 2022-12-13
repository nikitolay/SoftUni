--ex.1
CREATE DATABASE Minions
--ex.2
USE Minions
CREATE TABLE Minions 
(
Id INT PRIMARY KEY NOT NULL IDENTITY,
[Name] VARCHAR(50),
Age INT,
)
CREATE TABLE Towns
(
Id INT PRIMARY KEY NOT NULL IDENTITY,
[Name] VARCHAR(50)
)
--ex.3
ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)
--ex.4
INSERT INTO Towns
VALUES
('Sofia'),
('Plovdiv'),
('Varna')

INSERT INTO Minions
VALUES 
('Kevin',22,1),
('Bob',15,3),
('Steward',NULL,2)

--ex.5
TRUNCATE TABLE Minions
--ex.6
DROP TABLE Minions
DROP TABLE Towns
--ex.7

CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX),
Height DECIMAL(18,2),
[Weight] DECIMAL(18,2),
Gender BIT NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

--ex.8
CREATE TABLE Users
(
Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX) 
CHECK(DATALENGTH(ProfilePicture) <= 90 * 1024),
LastLoginTime DATETIME2 NOT NULL,
IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
VALUES
('Pesho0', '12345', '05.19.2020', 0),
('Pesho1', '12345', '05.19.2020', 1),
('Pesho2', '12345', '05.19.2020', 0),
('Pesho3', '12345', '05.19.2020', 1),
('Pesho4', '12345', '05.19.2020', 1)
--ex.9
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07E4D454DD

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY(Id,Username)
--ex.10
ALTER TABLE Users
ADD CONSTRAINT CK_PasswordAtLeast5Symbols 
CHECK(LEN([Password])>=5)
--ex.11
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT
GETDATE() FOR LastLoginTime
--ex.12
ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLength 
CHECK (LEN(Username)>=3)

--ex.13
CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
Notes VARCHAR(500)
)
CREATE TABLE Genres
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
Notes VARCHAR(500)
)
CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
Notes VARCHAR(500)
)
CREATE TABLE Movies
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Title VARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear DATE NOT NULL,
[Length] DECIMAL(18,2) NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Notes VARCHAR(500)
)
--ex.16
CREATE DATABASE SoftUni
USE SoftUni
CREATE TABLE Towns
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE Addresses 
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
AddressText VARCHAR(150) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id)
)
CREATE TABLE Departments 
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE Employees  
(
Id INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(50) NOT NULL,
MiddleName VARCHAR(50),
LastName VARCHAR(50) NOT NULL,
JobTitle VARCHAR(50) NOT NULL,
DepartmentId INT REFERENCES Departments(Id) NOT NULL,
HireDate DATE ,
Salary DECIMAL(18,2),
AddressId INT REFERENCES Addresses(Id),
)
--ex.18
INSERT INTO Towns([Name])
	VALUES
			('Sofia'),
			('Plovdiv'),
			('Varna'),
			('Burgas')


INSERT INTO Departments([Name])
	VALUES
			('Engineering'),
			('Sales'),
			('Marketing'),
			('Software Development'),
			('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES
			('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00),
			('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000.00),
			('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
			('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00),
			('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88)
--ex.19
SELECT * FROM Towns 


SELECT * FROM Departments 


SELECT * FROM Employees 


--ex.20

SELECT * FROM Towns 
ORDER BY [Name]

SELECT * FROM Departments 
ORDER BY [Name]

SELECT * FROM Employees 
ORDER BY FirstName

--ex.21
SELECT [Name] FROM Towns 
ORDER BY [Name]

SELECT [Name] FROM Departments 
ORDER BY [Name]

SELECT FirstName,LastName,JobTitle,Salary FROM Employees 
ORDER BY FirstName

--ex.22

UPDATE Employees
SET Salary+=Salary*0.10

--ex.15
CREATE DATABASE Hotel

USE Hotel

CREATE TABLE Employees(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		LastName NVARCHAR(20) NOT NULL,
		Title NVARCHAR(20) NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Customers(
		AccountNumber INT PRIMARY KEY NOT NULL,
		FirstName NVARCHAR(20) NOT NULL,
		LastName NVARCHAR(20) NOT NULL,
		PhoneNumber INT NOT NULL,
		EmergencyName NVARCHAR(10),
		EmergencyNumber INT,
		NOTES NVARCHAR(100)
)

CREATE TABLE RoomStatus(
		RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE RoomTypes(
		RoomType NVARCHAR(30) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE BedTypes(
		BedType NVARCHAR(20) PRIMARY KEY NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Rooms(
		RoomNumber INT PRIMARY KEY NOT NULL,
		RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType) NOT NULL,
		BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType) NOT NULL,
		Rate INT,
		RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) NOT NULL,
		NOTES NVARCHAR(100)
)

CREATE TABLE Payments(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
		PaymentDate DATE NOT NULL,
		AccountNumber INT NOT NULL,
		FirstDateOccupied DATE,
		LastDateOccupied DATE,
		TotalDays INT,
		AmountCharged INT,
		TaxRate DECIMAL(3,2) NOT NULL,
		TaxAmount INT NOT NULL,
		PaymentTotal INT,
		Notes NVARCHAR(30)
)

CREATE TABLE Occupancies(
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
		DateOccupied DATE NOT NULL,
		AccountNumber INT NOT NULL,
		RoomNumber INT NOT NULL,
		RateApplied INT NOT NULL,
		PhoneCharge INT,
		Notes NVARCHAR(20)
)

INSERT INTO Employees(FirstName, LastName, Title)
VALUES
('Ivan', 'Kurtacha', 'Zaglabie'),
('Ivan1', 'Kurtacha', 'Zaglabie'),
('Ivan2', 'Kurtacha', 'Zaglabie')


INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber)
VALUES
(1542, 'iVAN', 'kurtacha', 0884552, 'Malinkov', 07744),
(1522, 'iVAN2', 'kurtacha', 0884552, 'Malinkov', 07744),
(1532, 'iVAN3', 'kurtacha', 0884552, 'Malinkov', 07744)

INSERT INTO RoomStatus(RoomStatus)
VALUES
('Available'),
('Busy'),
('busy2')

INSERT INTO RoomTypes(RoomType)
VALUES
('squad'),
('duo'),
('solo')

INSERT INTO BedTypes(BedType)
VALUES
('adult'),
('baby'),
('teen')

INSERT INTO Rooms(RoomNumber, RoomType, BedType, RoomStatus)
VALUES
(1425, 'squad', 'adult', 'Busy'),
(1456, 'duo', 'baby', 'busy2'),
(14266, 'solo', 'teen', 'Available')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, TaxRate, TaxAmount)
VALUES
(1, '04.18.2020', 23 , 2.58, 550),
(2, '04.18.2020', 44 , 4.58, 533),
(2, '04.18.2020', 12, 1.58, 512)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied)
VALUES
(1, '12.24.2020', 17, 1, 85),
(2, '12.24.2020', 77, 2, 65),
(3, '12.24.2020', 177, 4, 12)

--ex.23
UPDATE Payments
SET TaxRate-=TaxRate*0.03

SELECT TaxRate FROM Payments
--ex.24
TRUNCATE TABLE Occupancies