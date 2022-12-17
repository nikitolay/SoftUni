USE SoftUni
--ex.1
SELECT EmployeeID,JobTitle,a.AddressID,a.AddressText 
FROM Employees e
JOIN Addresses a ON e.AddressID=a.AddressID
--ex.2
SELECT TOP(50) FirstName,LastName ,t.Name,a.AddressText
FROM Employees e
JOIN Addresses a ON e.AddressID=a.AddressID
JOIN Towns t ON a.TownID=t.TownID
ORDER BY FirstName,LastName
--ex.3
SELECT EmployeeID,FirstName,LastName ,d.[Name]
FROM Employees e
JOIN Departments d ON e.DepartmentID=d.DepartmentID
WHERE d.[Name]='Sales'
ORDER BY e.EmployeeID
--ex.4
SELECT TOP(5) EmployeeID,FirstName,Salary,d.[Name]
FROM Employees e
JOIN Departments d ON e.DepartmentID=d.DepartmentID
WHERE Salary>15000
ORDER BY e.DepartmentID
--ex.5
SELECT TOP(3) e.EmployeeID,e.FirstName
FROM Employees e
LEFT JOIN EmployeesProjects p ON e.EmployeeID=p.EmployeeID
WHERE p.ProjectID IS NULL
ORDER BY e.EmployeeID
--ex.6
SELECT FirstName,LastName,HireDate,d.[Name]
FROM Employees e
JOIN Departments d ON e.DepartmentID=d.DepartmentID
WHERE HireDate>'1999-01-01' AND d.[Name] IN ('Sales','Finance')
--ex.7
SELECT TOP(5) e.EmployeeID,FirstName,p.Name
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID=ep.EmployeeID
JOIN Projects p ON ep.ProjectID=p.ProjectID
WHERE p.StartDate>'2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID
--ex.8
SELECT e.EmployeeID,FirstName,
CASE 
	WHEN YEAR(p.StartDate) >=2005 THEN NULL
	ELSE p.[Name]
	END
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID=ep.EmployeeID
JOIN Projects p ON ep.ProjectID=p.ProjectID
WHERE e.EmployeeID=24
--ex.9
SELECT e.EmployeeID,e.FirstName,e.ManagerID ,m.FirstName
FROM Employees e
LEFT JOIN Employees m ON m.EmployeeID=e.ManagerID
WHERE e.ManagerID IN(3,7)
ORDER BY e.EmployeeID
--ex.10
SELECT TOP(50) e.EmployeeID, 
(e.FirstName + ' ' + e.LastName) AS EmployeeName,
(m.FirstName + ' ' + m.LastName) AS ManagerName,
d.[Name] AS DepartmentName
FROM Employees e
LEFT JOIN Employees m ON m.EmployeeID=e.ManagerID
LEFT JOIN Departments d ON e.DepartmentID=d.DepartmentID
ORDER BY e.EmployeeID
--ex.11
SELECT TOP(1)
AVG(e.Salary) AS MinAverageSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY MinAverageSalary

-- Or

SELECT MIN(a.AverageSalary) AS MinAverageSalary
FROM 
(
	SELECT e.DepartmentID, 
	AVG(e.Salary) AS AverageSalary
	FROM Employees AS e
	GROUP BY e.DepartmentID
) AS a

--ex.12
USE Geography

SELECT c.CountryCode,m.MountainRange,p.PeakName,p.Elevation
FROM Peaks p
JOIN Mountains m ON p.MountainId=m.Id
JOIN MountainsCountries mc ON m.Id=mc.MountainId
JOIN Countries c ON mc.CountryCode=c.CountryCode
WHERE c.CountryName='Bulgaria' AND p.Elevation>2835
ORDER BY p.Elevation DESC

--ex.13

SELECT CountryCode,COUNT(MountainId) AS MountainRanges
FROM MountainsCountries AS mc
WHERE mc.CountryCode IN ('BG','US','RU')
GROUP BY CountryCode

--ex.14
SELECT TOP(5) c.CountryName,r.RiverName
FROM Countries c
LEFT JOIN CountriesRivers cr ON c.CountryCode=cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId=r.Id
WHERE c.ContinentCode='AF'
ORDER BY c.CountryName
--ex.15
SELECT ContinentCode, CurrencyCode, CurrencyCount AS CurrencyUsage FROM
(
	SELECT ContinentCode, CurrencyCode, CurrencyCount, 
	DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
	FROM
	(
		SELECT ContinentCode, CurrencyCode, 
		COUNT(*) AS CurrencyCount
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
	) AS CurrencyCountQuery
	WHERE CurrencyCount > 1
) AS CurrencyRankingQuery
WHERE CurrencyRank = 1
--ex.16
SELECT COUNT(*) 
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode=mc.CountryCode
WHERE mC.MountainId IS NULL
--ex.17
SELECT TOP(5) CountryName, 
MAX(p.Elevation) AS [HighestPeakElevation], 
MAX(r.Length) AS [LongestRiverLength]
FROM Countries c
LEFT JOIN CountriesRivers cr ON c.CountryCode=cr.CountryCode
LEFT JOIN Rivers r ON r.Id=cr.RiverId
LEFT JOIN MountainsCountries mc ON c.CountryCode=mc.CountryCode
LEFT JOIN Mountains m ON mc.MountainId=m.Id
LEFT JOIN Peaks p ON p.MountainId=m.Id
GROUP BY c.CountryName
ORDER BY  [HighestPeakElevation] DESC,[LongestRiverLength] DESC,c.CountryName
--ex.18
SELECT TOP(5) Country,
	CASE
		WHEN PeakName IS NULL THEN '(no highest peak)'
		ELSE PeakName
	END AS [Highest Peak Name],
	CASE
		WHEN Elevation IS NULL THEN 0
		ELSE Elevation
	END AS [Highest Peak Elevation], 
	CASE
		WHEN MountainRange IS NULL THEN '(no mountain)'
		ELSE MountainRange
	END AS [Mountain]
FROM
(
	SELECT *,
	DENSE_RANK() OVER (PARTITION BY Country ORDER BY Elevation DESC) AS PeakRank
	FROM
	(
		SELECT c.CountryName AS Country, 
		p.PeakName, p.Elevation, m.MountainRange
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON p.MountainId = m.Id
	) AS FullInformationQuery
) AS PeakRankingQuery
WHERE PeakRank = 1
ORDER BY Country, [Highest Peak Elevation]
