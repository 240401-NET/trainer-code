# Subquery

## Definition:  
Subqueries (also known as inner queries or nested queries) are a tool for performing operations in multiple steps. Very often used for filtering, aggregation, or conditional logic.
## Important rules:

- Subqueries can be used with SELECT, UPDATE, INSERT, and DELETE statements along with the expression operator.
- You can place the Subquery in a number of SQL clauses: WHERE clause, HAVING clause, FROM clause.
- The subquery generally executes <b>first</b> when the subquery doesn’t have any co-relation with the main query, when there is a co-relation the parser takes the decision on the fly on which query to execute on precedence and uses the output of the subquery accordingly.
- Subquery must be enclosed in parentheses.

  ### Syntax:
```
SELECT column_name
FROM table_name
WHERE column_name expression operator 
    ( SELECT COLUMN_NAME  from TABLE_NAME   WHERE ... );
```
  
### Types

- <b>Scalar subquery:</b> Returns a single value <b>exactly one row and exactly one column</b>, Scalar subqueries are often used within expressions.
```
SELECT InvoiceId, CustomerId, (SELECT Count(*) FROM InvoiceLine WHERE InvoiceId = 3) AS Number_Tracks_Purchased,
Total
FROM Invoice AS Inv
WHERE InvoiceId = 3;
```
- <b>Row Subqueries</b> Returns a single row with multiple columns.It can be used with operators such as IN, ANY, ALL, etc.

```
  SELECT CustomerID, Company, FirstName, LastName, Phone, Email
  FROM Customer
  WHERE Email IN (SELECT Email FROM Customer WHERE Email LIKE '%gmail.com%')
  ORDER BY Email;
```

- <b>Table Subqueries</b> Returns entire tables.

```
SELECT * From (SELECT FirstName, LastName, City, Phone, Email FROM Customer) as CustomerSubquery;
);

```

- <b>Column Subqueries (Correlated):</b> A subquery that refers to columns from the outer query. Correlated subqueries are evaluated once for each row processed by the outer query.

```
SELECT CustomerID, Company, FirstName, LastName, Phone, Email,
(SELECT COUNT(*) FROM Customer WHERE Email LIKE '%gmail.com%') AS CustomerCount,
(SELECT COUNT(*) FROM Customer WHERE Email LIKE '%yahoo.com%') AS CustomerCount2
FROM Customer
ORDER BY CustomerCount DESC;

```
  


### Best Practices

- Use subqueries judiciously as they can complicate the SQL statements and may lead to performance issues.
- Consider alternatives like joins or temporary tables if the subquery makes the query substantially slower or harder to read.
- Always test subqueries for performance in the context of the larger database system.

Source: 
https://datagrad.medium.com/the-anatomy-of-sql-subqueries-a-data-scientists-guide-1d5410736029#:~:text=Let%E2%80%99s%20start%20by%20classifying%20subqueries%20into%20different%20types,with%20multiple%20rows.%20Table%20Subqueries%3A%20Returns%20entire%20tables.

https://www.geeksforgeeks.org/sql-subquery/#

