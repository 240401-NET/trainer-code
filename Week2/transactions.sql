-- Transaction
-- Transaction is a collection of SQL statements that either succeed or fail together/as a unit
-- You manage transactions with TCL sublaguage: transaction control language
-- TCL ex: Commit, Savepoint, Rollback

-- Properties of Transaction (ACID)
-- Atomicity : all statements in a transaction either succeeds or fails as a whole
-- Consistency : When a transaction commits, it should follow the rules in the db tables
-- Isolation : Transaction should be isolated and free from other sql operations
-- Durability : When the transaction commits, it's saved to a persistent/durable storage

-- Isolation Levels
-- Read Uncommitted : allows all 3 phenomena
-- Read Committed : does not allow dirty read
-- Repeatable Read : does not allow dirty and non-repeatable read
-- Serializable : does not allow all 3 phenomena

-- Read phenomena
-- Dirty Read: your transaction is reading changes made by other transactions that hasn't been commited (it has chances of rolling back)
-- NonRepeatable Read: your transaction is reading committed changes made by other transactions
-- Phantom Read: your transaction is seeing newly created records or not seeing certain records because it got delete by other transactions

-- Microsoft Learn on Transaction: https://learn.microsoft.com/en-us/sql/t-sql/language-elements/transactions-transact-sql?view=sql-server-ver16
-- Microsoft Ref on Isolation Levels: https://learn.microsoft.com/en-us/sql/odbc/reference/develop-app/transaction-isolation-levels?view=sql-server-ver16

Begin TRANSACTION CreateInvoiceWithTracks
BEGIN TRY
    INSERT INTO Invoice (CustomerId, InvoiceDate, Total) Values (1, getDate(), 1.98);
    Declare @invoiceId INT
    SET @invoiceId = Scope_identity()
    INSERT INTO InvoiceLine (InvoiceId, TrackId, UnitPrice, Quantity) values (@invoiceId, 1, 0.99, 1), (@invoiceId, 2, 0.99, 1);
    COMMIT TRANSACTION
END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH

Select * from Invoice