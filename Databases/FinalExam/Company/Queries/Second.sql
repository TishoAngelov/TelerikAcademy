USE Company
GO

SELECT d.Id, d.Name AS [Department name], (
SELECT COUNT(*)
FROM Employees AS e
WHERE d.Id = e.DepartmentId
) AS [Empoyees count]
FROM Departments AS d
ORDER BY [Empoyees count] DESC