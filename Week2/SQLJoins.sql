select * from Employee;

select e1.EmployeeId, e1.LastName, e1.FirstName, e2.LastName, e2.FirstName 
from Employee as e1 join Employee as e2 on e1.ReportsTo = e2.EmployeeId

select count(*) from InvoiceLine inner join Track on InvoiceLine.TrackId = Track.TrackId

select count(*) from InvoiceLine left join Track on InvoiceLine.TrackId = Track.TrackId

select count(*) from InvoiceLine right join Track on InvoiceLine.TrackId = Track.TrackId

select top 10 * from Track join MediaType on Track.MediaTypeId = MediaType.MediaTypeId

select Count(MediaType.Name), MediaType.Name from MediaType join Track on Track.MediaTypeId = MediaType.MediaTypeId Group By MediaType.Name

-- Set Ops : Set Operation on select statements
-- The result sets MUST BE THE SAME SHAPE
-- Difference between Union vs Union ALL
-- Union(A v B), Union All, Intersect (A ^ B), Except (A - (A ^ B))
select FirstName, LastName, Phone from Customer
EXCEPT
select FirstName, LastName, Phone from Employee