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


