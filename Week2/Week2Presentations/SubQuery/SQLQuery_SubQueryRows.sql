
--SCALAR SQ example
SELECT CustomerID, Company, FirstName, LastName, Phone, Email,
(SELECT COUNT(*) FROM Customer WHERE Email LIKE '%gmail.com%') AS CustomerCount
FROM Customer;

--ROW SQ example

--SINGLE ROW
SELECT FirstName, LastName, HireDate
FROM dbo.Employee
WHERE HireDate = (SELECT MIN(HireDate)FROM dbo.Employee WHERE YEAR(HireDate) = 2002);

--MULTI ROW
SELECT FirstName, LastName, HireDate
FROM dbo.Employee
WHERE HireDate IN (SELECT HireDate FROM dbo.Employee WHERE YEAR(HireDate) = 2002)
ORDER BY HireDate DESC;

SELECT HireDate FROM dbo.Employee WHERE YEAR(HireDate) = 2002


--COLUMN SQ
SELECT CustomerID, Company, FirstName, LastName, Phone, Email
FROM Customer
WHERE Email IN (SELECT Email FROM Customer WHERE Email LIKE '%gmail.com%')
ORDER BY Email;

--TABLE SQ
SELECT CustomerID, Company, FirstName, LastName, Phone, Email
FROM Customer
WHERE Email IN (SELECT Email FROM Customer WHERE Email LIKE '%gmail.com%')
ORDER BY Email;