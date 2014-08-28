-- Select some query and press F5 to execute only the selected query.
-- You may need to type USE TelerikAcademy to run the queries. They run for my database without USE.

-- 01. Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company. Use a nested SELECT statement.

SELECT concat(e.FirstName, ' ', e.MiddleName, ' ', e.LastName) AS [Employee full name], e.Salary
FROM Employees AS e
WHERE e.Salary = (
SELECT MIN(e2.Salary)
FROM Employees AS e2
)

-- 02. Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

SELECT concat(e.FirstName, ' ', e.MiddleName, ' ', e.LastName) AS [Employee full name], e.Salary
FROM Employees AS e
WHERE e.Salary <= 1.1 * (
SELECT MIN(e2.Salary)
FROM Employees AS e2
)

-- 03. Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department. Use a nested SELECT statement.

SELECT concat(e.FirstName, ' ', e.MiddleName, ' ', e.LastName) AS [Employee full name], e.Salary, d.Name AS [Department name]
FROM Employees AS e
INNER JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.Salary = (
SELECT MIN(e2.Salary)
FROM Employees AS e2
)

-- 04. Write a SQL query to find the average salary in the department #1.

SELECT AVG(Salary) AS [Average salary for department #1]
FROM Employees
WHERE DepartmentID = 1

-- 05. Write a SQL query to find the average salary  in the "Sales" department.

SELECT AVG(e.Salary) AS [Average salary for department Sales]
FROM Employees AS e
INNER JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'

-- 06. Write a SQL query to find the number of employees in the "Sales" department.

SELECT COUNT(e.EmployeeID) AS [Count of employees in department Sales]
FROM Employees AS e
INNER JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'

-- 07. Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(EmployeeID) AS [Count employees with manager]
FROM Employees
WHERE ManagerID IS NOT NULL

-- 08. Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(EmployeeID) AS [Count employees without manager]
FROM Employees
WHERE ManagerID IS NULL

-- 09. Write a SQL query to find all departments and the average salary for each of them.

SELECT d.Name AS [Department name], AVG(e.Salary) AS [Average salary]
FROM Departments AS d
INNER JOIN Employees AS e
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

-- 10. Write a SQL query to find the count of all employees in each department and for each town.

SELECT d.Name AS [Department name], t.Name AS [Town], COUNT(e.EmployeeID) AS [Employees count]
FROM Employees AS e
INNER JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
INNER JOIN Addresses AS a
ON a.AddressID = e.AddressID
INNER JOIN Towns AS t
ON t.TownID = a.TownID
GROUP BY d.Name, t.Name

-- 11. Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.

SELECT (m.FirstName + ' ' + m.LastName) AS [Manager name], m.ManagerID
FROM Employees AS m
WHERE 5 = (
SELECT COUNT(e.EmployeeID)
FROM Employees AS e
WHERE e.ManagerID = m.ManagerID
GROUP BY e.ManagerID
)

-- 12. Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

SELECT (e.FirstName + ' ' + e.LastName) AS [Employee name], ISNULL((m.FirstName + ' ' + m.LastName) , '(no manager)') AS [Manager name]
FROM Employees AS e
LEFT OUTER JOIN Employees AS m
ON m.EmployeeID = e.ManagerID

-- 13. Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 14. Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.

SELECT (CONVERT(VARCHAR(10), GETDATE(), 104) + ' ' + CONVERT(VARCHAR(12), GETDATE(), 114)) AS [Current date]

-- 15. Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint. Define the primary key column as identity to facilitate inserting records. Define unique constraint to avoid repeating usernames. Define a check constraint to ensure the password is at least 5 characters long.

USE TelerikAcademy
-- DROP TABLE Users

CREATE TABLE Users
(
UserID INT IDENTITY PRIMARY KEY,
Username NVARCHAR(20) UNIQUE,
Password NVARCHAR(20) CHECK (LEN(Password) >= 5),
FullName NVARCHAR(100) NOT NULL,
LastLoginTime DATE DEFAULT NULL
)
GO

-- 16. Write a SQL statement to create a view that displays the users from the Users table that have been in the system today. Test if the view works correctly.

USE TelerikAcademy
GO

CREATE VIEW  [UsersLoggedToday] AS 
SELECT *
FROM Users
WHERE DAY(Users.LastLoginTime) = DAY(GETDATE())
GO

-- Test it
SELECT * FROM [UsersLoggedToday]

-- 17. Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint). Define primary key and identity column.

CREATE TABLE Groups
(
GroupID int IDENTITY PRIMARY KEY,
Name NVARCHAR(50) UNIQUE
)

-- 18. Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new column and as well in the Groups table. Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

ALTER TABLE Users
ADD GroupID int,
CONSTRAINT FK_Users_Groups
  FOREIGN KEY (GroupID)
  REFERENCES Groups(GroupID)
GO

INSERT INTO Groups(Name)
VALUES
('C#'),
('JavaScript'),
('PHP'),
('DSA')
GO

UPDATE Users
SET GroupID = 1
WHERE UserID = 1
GO

USE TelerikAcademy
GO

UPDATE Users
SET GroupID = 2
WHERE UserID = 2
GO

-- 19. Write SQL statements to insert several records in the Users and Groups tables.

USE TelerikAcademy
GO

INSERT INTO Groups(Name)
VALUES
('OOP'),
('C#2'),
('HQC')
GO

INSERT INTO Users(Username, Password, FullName, LastLoginTime, GroupID)
VALUES
('Ivan66', 'azsymivan', 'Ivan Ivanoff', '2014-8-23', 4),
('Mariika78', 'maria78', 'Maria Todorova', '2014-8-24', 4)
GO

-- 20. Write SQL statements to update some of the records in the Users and Groups tables.

USE TelerikAcademy
GO

UPDATE Users
SET GroupID = 5
WHERE UserID = 1
GO

USE TelerikAcademy
GO

UPDATE Groups
SET Name = 'Data Structures and Algorithms'
WHERE GroupID = 4
GO

-- 21. Write SQL statements to delete some of the records from the Users and Groups tables.

USE TelerikAcademy
GO

DELETE FROM Users
WHERE UserID = 2
GO

USE TelerikAcademy
GO

DELETE FROM Groups
WHERE GroupID = 7
GO

-- 22. Write SQL statements to insert in the Users table the names of all employees from the Employees table. Combine the first and last names as a full name. For username use the first letter of the first name + the last name (in lowercase). Use the same for the password, and NULL for last login time.

USE TelerikAcademy
GO

INSERT INTO Users(Username, Password, FullName)
SELECT lower(SUBSTRING(e.FirstName, 1, 1) + e.LastName), lower(SUBSTRING(e.FirstName, 1, 1) + e.LastName), (e.FirstName + ' ' + e.LastName)
FROM Employees AS e
WHERE LEN(e.LastName) >= 5
GO

-- 23. Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.

USE TelerikAcademy
GO

UPDATE Users
SET Password = NULL
WHERE LastLoginTime <= CONVERT(NVARCHAR(12), '2010-03-10', 121)
OR LastLoginTime IS NULL
GO

-- 24. Write a SQL statement that deletes all users without passwords (NULL password).

USE TelerikAcademy
GO

DELETE FROM Users
WHERE Password IS NULL
GO

-- 25. Write a SQL query to display the average employee salary by department and job title.

SELECT AVG(e.Salary) AS [Average salary], d.Name AS [Department name], e.JobTitle AS [Job Title]
FROM Employees AS e
INNER JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name, e.JobTitle

-- 26. Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.



-- 27. Write a SQL query to display the town where maximal number of employees work.



-- 28. Write a SQL query to display the number of managers from each town.



-- 29. Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments). Don't forget to define  identity, primary key and appropriate foreign key. 
--  	Issue few SQL statements to insert, update and delete of some data in the table.
--  	Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. For each change keep the old record data, the new record data and the command (insert / update / delete).



-- 30. Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables. At the end rollback the transaction.



-- 31. Start a database transaction and drop the table EmployeesProjects. Now how you could restore back the lost table data?



-- 32. Find how to use temporary tables in SQL Server. Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.

