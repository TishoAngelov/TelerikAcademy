USE Company
GO

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Employee full name], e.YearSalary AS [Year salary]
FROM Employees AS e
WHERE e.YearSalary BETWEEN 100000 AND 150000
ORDER BY e.YearSalary ASC