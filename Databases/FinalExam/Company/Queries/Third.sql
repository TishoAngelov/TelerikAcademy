USE Company
GO

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [Employee full name],
	p.Name AS [Project name],
	d.Name AS [Department name],
	ep.StartingDate AS [Project starting date],
	ep.EndingDate AS [Project ending date],
	(
		SELECT COUNT(*)
		FROM Reports AS r
		WHERE r.EmployeeId = e.Id
		AND r.TimeOfReporting BETWEEN ep.StartingDate AND ep.EndingDate
	) AS [Reports count]
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
	ON ep.EmployeeId = e.Id
INNER JOIN Projects AS p
	ON p.Id = ep.ProjectId
INNER JOIN Departments AS d
	ON d.Id = e.DepartmentId
ORDER BY e.Id, p.Id