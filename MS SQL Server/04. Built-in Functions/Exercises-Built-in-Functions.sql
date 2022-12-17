USE SoftUni
--ex.1
SELECT FirstName,LastName FROM Employees
WHERE FirstName LIKE'Sa%'
--ex.2
SELECT FirstName,LastName FROM Employees
WHERE LastName LIKE'%ei%'
--ex.3
SELECT FirstName FROM Employees
WHERE DepartmentID IN(3,10)
AND DATEPART(Year,HireDate) BETWEEN 1995 AND 2005
--ex.4
SELECT FirstName,LastName FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'
--ex.5
SELECT [Name] FROM Towns
WHERE LEN([Name]) IN(5,6)
ORDER BY [Name]
--ex.6
SELECT TownID, [Name] FROM Towns
WHERE LEFT([Name],1) IN ('M','K','B','E')
ORDER BY [Name]
--ex.7
SELECT TownID, [Name] FROM Towns
WHERE LEFT([Name],1) NOT IN ('R','B','D')
ORDER BY [Name]
--ex.8
CREATE VIEW V_EmployeesHiredAfter2000
AS
(SELECT FirstName,LastName FROM Employees
WHERE YEAR(HireDate)>2000)
--ex.9
SELECT FirstName,LastName FROM Employees
WHERE LEN(LastName)=5
--ex.10
SELECT [EmployeeID]
    , [FirstName]
    , [LastName]
    , [Salary]
    , DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC
--ex.11
SELECT * FROM
(
	SELECT EmployeeID,FirstName,LastName,Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000

) AS [Rank Table]
WHERE [Rank] =2
ORDER BY Salary DESC
--ex.12
USE Geography

SELECT CountryName AS [Country Name], IsoCode AS [Iso Code] FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode
--ex.13
SELECT p.PeakName,r.RiverName,
LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) - 1), r.RiverName)) AS Mix 
FROM Peaks p, Rivers r
WHERE RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
ORDER BY Mix

---ex.14
USE Diablo

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM Games
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], [Name]
--ex.15

SELECT [Username], 
SUBSTRING([Email], CHARINDEX('@', Email, 1) + 1, LEN([Email]) - CHARINDEX('@', [Email], 1))
AS [Email Provider]
FROM Users 
ORDER BY [Email Provider], [Username]
--ex.16
SELECT Username, IpAddress FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--ex.17
SELECT [Name],
	CASE
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 24 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM Games
ORDER BY [Name], Duration, [Part of the Day]

--ex.18
USE Orders

SELECT [ProductName], OrderDate, 
DATEADD(DAY, 3, OrderDate) AS [Pay Due],
DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

--ex.19

SELECT DATEDIFF(YEAR, '2000-12-07 00:00:00.000', GETDATE()) AS [Age in Years]
,DATEDIFF(MONTH, '2000-12-07 00:00:00.000', GETDATE()) AS [Age in Months]
,DATEDIFF(DAY, '2000-12-07 00:00:00.000', GETDATE()) AS [Age in Days]
,DATEDIFF(MINUTE, '2000-12-07 00:00:00.000', GETDATE()) AS [Age in Minutes]