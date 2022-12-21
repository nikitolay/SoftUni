USE SoftUni

GO
--ex.1
CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT FirstName,LastName 
	FROM Employees
	WHERE Salary>35000
END

EXEC usp_GetEmployeesSalaryAbove35000 

GO
--ex.2
CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4))
AS
BEGIN

	SELECT FirstName,LastName 
	FROM Employees
	WHERE Salary>=@Number
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

GO
--ex.3

CREATE OR ALTER PROC usp_GetTownsStartingWith (@Text VARCHAR(50))
AS
BEGIN
		SELECT [Name] 
		FROM Towns
		WHERE [Name] LIKE (@Text+'%')
END

GO

EXEC usp_GetTownsStartingWith 'b'

--ex.4
CREATE OR ALTER PROC usp_GetEmployeesFromTown (@TownName VARCHAR(50))
AS
BEGIN 
		SELECT FirstName,LastName
		FROM Employees e
		JOIN Addresses a ON e.AddressID=a.AddressID
		JOIN Towns t ON a.TownID = t.TownID
		WHERE t.Name =@TownName
END

EXEC usp_GetEmployeesFromTown 'Sofia'

--ex.
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel (@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN   

	DECLARE @result VARCHAR(10)

	IF (@salary <30000)
		SET @result= 'Low'
	ELSE IF (@salary  BETWEEN 30000 AND 50000)
			SET @result=  'Average'
	ELSE 
		SET @result= 'High'
	RETURN @result
END

SELECT dbo.ufn_GetSalaryLevel(13500)

GO

--ex.6
CREATE OR ALTER PROC usp_EmployeesBySalaryLevel (@LevelOfSalary VARCHAR(50))
AS

BEGIN 
	SELECT FirstName,LastName
	FROM Employees e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary)=@LevelOfSalary

END

EXEC usp_EmployeesBySalaryLevel 'High'

GO
--ex.7
CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(15)) 
RETURNS BIT
AS
BEGIN

	DECLARE @Result BIT=1
	DECLARE @i INT =1

	WHILE (@i<=LEN(@word))
	BEGIN

		IF CHARINDEX(SUBSTRING(@word,@i,1),@setOfLetters)<=0
		BEGIN
				SET @Result =0
				RETURN @Result
		END

		SET @i+=1
	END
	RETURN @Result
END

SELECT dbo.ufn_IsWordComprised('oistmiahf','halves')

--ex.8
CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment(@departmentId INT) 
AS
BEGIN

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN 
	(
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId
	)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN
	(
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId
	)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees
	WHERE DepartmentID = @departmentId

END

GO

USE Bank

GO

--ex.9

CREATE OR ALTER PROC usp_GetHoldersFullName 
AS
BEGIN
	SELECT FirstName+' '+LastName AS [Full Name]
	FROM AccountHolders

END

EXEC usp_GetHoldersFullName 

GO
--ex.10
CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(18,4))
AS
BEGIN

	SELECT FirstName,LastName
	FROM AccountHolders ah
	JOIN Accounts a ON A.AccountHolderId=AH.Id
	GROUP BY FirstName,LastName
	HAVING SUM(a.Balance)>@number
	ORDER BY FirstName,LastName

END

EXEC usp_GetHoldersWithBalanceHigherThan 10000

--ex.11

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4),@rate FLOAT,@years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
		DECLARE @result DECIMAL(18,4)
		SET @result=@sum*(POWER((1+@rate),@years))
		RETURN @result

END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--ex.12
CREATE OR ALTER PROC usp_CalculateFutureValueForAccount (@accountId INT,@yearlyInterestRate FLOAT)
AS
BEGIN

	SELECT a.Id,FirstName,LastName,a.Balance,dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5)
	FROM Accounts a
	JOIN AccountHolders ac ON a.AccountHolderId=ac.Id
	WHERE a.AccountHolderId=@accountId

END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

GO

USE Diablo

--ex.13

CREATE FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(100))
RETURNS TABLE
AS
RETURN SELECT SUM(Cash) AS SumCash FROM
	(
		SELECT g.Name, ug.Cash,
			ROW_NUMBER() OVER (PARTITION BY g.Name ORDER BY ug.Cash DESC) AS RowNum
		FROM Games g
		JOIN UsersGames AS ug ON g.Id = ug.GameId
		WHERE g.Name = @gameName
	) AS RowNumQuery
	WHERE RowNum % 2 != 0

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')
