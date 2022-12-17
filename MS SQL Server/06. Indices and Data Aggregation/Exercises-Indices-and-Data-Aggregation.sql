--ex.1
USE Gringotts

SELECT COUNT(*) FROM WizzardDeposits
--ex.2
SELECT MAX(MagicWandSize) FROM WizzardDeposits
--ex.3
SELECT DepositGroup,MAX(MagicWandSize) FROM WizzardDeposits
GROUP BY DepositGroup
--ex.4
SELECT TOP(2) DepositGroup FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)
--ex.5
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits
GROUP BY DepositGroup
--ex.6
SELECT DepositGroup, SUM(DepositAmount) FROM WizzardDeposits
WHERE MagicWandCreator='Ollivander family'
GROUP BY DepositGroup
--ex.7

SELECT DepositGroup, SUM(DepositAmount) AS Total FROM WizzardDeposits
WHERE MagicWandCreator='Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) <150000
ORDER BY Total DESC

--ex.8
SELECT DepositGroup,MagicWandCreator,MIN(DepositCharge) FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup

--ex.9
SELECT [AgeGroup],COUNT(*) FROM
(
		SELECT 
			CASE
				 WHEN  Age<=10 THEN '[0-10]'
				 WHEN  Age BETWEEN 11 AND 20 THEN '[11-20]'
				 WHEN  Age BETWEEN 21 AND 30 THEN '[21-30]'
				 WHEN  Age BETWEEN 31 AND 40 THEN '[31-40]'
				 WHEN  Age BETWEEN 41 AND 50 THEN '[41-50]'
				 WHEN  Age BETWEEN 41 AND 50 THEN '[51-60]'
				 ELSE '[60+]'		
		END AS [AgeGroup]
	FROM WizzardDeposits
) AS AgeGroupQuery
GROUP BY [AgeGroup]

--ex.10
SELECT LEFT(FirstName,1) FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName,1)

--ex.11
SELECT DepositGroup,IsDepositExpired,AVG(DepositInterest) FROM WizzardDeposits
WHERE DepositStartDate>'1985-01-01'
GROUP BY DepositGroup,IsDepositExpired
ORDER BY DepositGroup DESC,IsDepositExpired

--ex.12
SELECT SUM(Difference) AS SumDifference FROM
(
	SELECT FirstName AS [Host Wizard], 
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizard],
			LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizard Deposit],
			DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
	FROM WizzardDeposits
) AS LeadQuery
WHERE [Guest Wizard] IS NOT NULL

--ex.13
USE SoftUni

SELECT DepartmentID, SUM(Salary) FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--ex.14
SELECT DepartmentID, MIN(Salary) FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

--ex.15
SELECT * INTO EmployeesWithHighSalaries FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalaries
WHERE ManagerID=42

UPDATE EmployeesWithHighSalaries
SET Salary+=5000
WHERE DepartmentID=1

SELECT DepartmentID,AVG(Salary) FROM EmployeesWithHighSalaries
GROUP BY DepartmentID

--ex.16

SELECT DepartmentID,MAX(Salary) FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--ex.17

SELECT COUNT(Salary) FROM Employees
GROUP BY ManagerID
HAVING ManagerID IS NULL

--ex.18
SELECT DISTINCT DepartmentID, Salary AS ThirdHighestSalary FROM
(
	SELECT DepartmentID, Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM Employees
) AS SalaryRankQuery
WHERE SalaryRank = 3

--ex.19
SELECT TOP(10) e1.FirstName, e1.LastName, e1.DepartmentID
FROM Employees AS e1
WHERE e1.Salary > (
			SELECT AVG(Salary) AS AverageSalary
			FROM Employees AS e2
			WHERE e2.DepartmentID = e1.DepartmentID
			GROUP BY DepartmentID
)
ORDER BY DepartmentID

