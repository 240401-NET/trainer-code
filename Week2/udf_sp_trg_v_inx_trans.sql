-- UDF (User Defined Functions)
-- Table valued function, scalar functions
-- Functions can only have SELECT statetments
-- Functions MUST return a value
-- Functions can be used in SELECT, INSERT, UPDATE, ... etc about anywhere in SQL
-- They are optimized, but they do compile everytime you run


-- CREATE FUNCTION normalized_dndrpg.CharactersWithClasses()
-- Returns TABLE
-- AS
-- RETURN (select c.id as character_id, c.name as character_name, cl.name as class_name, cc.level as class_level 
-- from normalized_dndrpg.Characters as c 
-- join normalized_dndrpg.CharacterClasses as cc on c.id = cc.characterId 
-- join normalized_dndrpg.Classes as cl on cl.id = cc.classId);

-- DROP FUNCTION normalized_dndrpg.CharactersWithClasses

-- select * from normalized_dndrpg.CharactersWithClasses();

-- Scalar Function
-- DROP FUNCTION normalized_dndrpg.IncreaseCharacterAge

-- CREATE FUNCTION normalized_dndrpg.IncreaseCharacterAge
-- (
--     @characterId int,
--     @increaseBy int
-- )
-- returns int
-- AS
-- BEGIN
--     DECLARE @currAge int
--     SET @currAge = (SELECT age FROM normalized_dndrpg.Characters WHERE id = @characterId)
--     SET @currAge = @currAge + @increaseBy
--     RETURN @currAge
-- END

-- SELECT normalized_dndrpg.IncreaseCharacterAge(id, 10), * FROM normalized_dndrpg.Characters

-- Stored Procedures
-- DROP PROCEDURE sp_CharactersWithSameAge
-- CREATE PROCEDURE sp_CharactersWithSameAge
-- @age INT
-- AS
-- SELECT * FROM normalized_dndrpg.Characters WHERE age = @age

-- EXEC sp_CharactersWithSameAge @age = 2
-- CREATE PROCEDURE sp_CreateCharacterWithClass
-- @name NVARCHAR(max),
-- @hitpoints int,
-- @className NVARCHAR(20)
-- AS
-- INSERT INTO normalized_dndrpg.Characters (name, hitpoints) values (@name, @hitpoints)
-- DECLARE @charId int
-- SET @charId = (SELECT id FROM normalized_dndrpg.Characters where name = @name)
-- Declare @classId int
-- Set @classId = (SELECT id FROM normalized_dndrpg.Classes where name = @className)
-- INSERT INTO normalized_dndrpg.CharacterClasses (classId, characterId) VALUES (@classId, @charId)

-- sp_CreateCharacterWithClass @name = "mars", @hitpoints = 20, @className = "Rogue"

-- SELECT * FROM normalized_dndrpg.CharactersWithClasses()
-- EXEC sp_CharactersWithSameAge @age = 2

-- Triggers - are a special type of stored procedure that is attached to an event
-- DML : INSERT, UPDATE, DELETE
-- DDL : ALTER, DROP
-- LogOn

-- CREATE TRIGGER drop_prevention
-- ON DATABASE
-- FOR DROP_TABLE
-- AS
--     PRINT 'YOU MUST DROP THIS TRIGGER BEFORE YOU CAN DROP THIS TABLE'
-- --     ROLLBACK;

-- CREATE TRIGGER insert_print
-- ON dbo.hobbies
-- FOR INSERT
-- AS
--     PRINT 'inserting records'

-- insert into hobbies (id, name, description) values ('uawhefliuah', 'napping', 'I LOVE napping')

-- DROP TABLE hobbies

-- CREATE TRIGGER trPreventDropTable

-- ON DATABASE

-- FOR DROP_TABLE

-- AS

-- BEGIN

--     SET NOCOUNT ON;
 
--     -- Get the table schema and table name from EVENTDATA()

--     DECLARE @Schema SYSNAME = eventdata().value('(/EVENT_INSTANCE/SchemaName)[1]', 'sysname');

--     DECLARE @Table SYSNAME = eventdata().value('(/EVENT_INSTANCE/ObjectName)[1]', 'sysname');
 
--     IF @Schema = 'dbo' AND @Table = 'hobbies'

--     BEGIN

--         PRINT 'DROP TABLE Issued.';

--         -- Optional: error message for end user.

--         RAISERROR ('[dbo].[YourTableName] cannot be dropped.', 16, 1);

--         -- Rollback transaction for the DROP TABLE statement that fired the DDL trigger

--         ROLLBACK;

--     END

--     ELSE

--     BEGIN

--         -- Do nothing. Allow table to be dropped.

--         PRINT 'Table dropped: [' + @Schema + '].[' + @Table + ']';

--     END

-- END;
-- CREATE TABLE DROPME( id int identity)
-- DROP TABLE hobbies
-- DROP TRIGGER drop_prevention ON DATABASE

-- Views
-- CREATE VIEW CharactersWithClassesView
-- AS
-- select c.id as character_id, c.name as character_name, cl.name as class_name, cc.level as class_level 
-- from normalized_dndrpg.Characters as c 
-- join normalized_dndrpg.CharacterClasses as cc on c.id = cc.characterId 
-- join normalized_dndrpg.Classes as cl on cl.id = cc.classId

Select * FROM CharactersWithClassesView Where character_name = 'Fatima'

select * from CustomerPurchaseView

-- Index 
-- Clustered Index - 1 ci per table. EX: Primary Key's are clustered index. These affect the physical ordering of the data
-- Non-clustered Index - many unclustered indices per table, they don't affect the physical ordering of the data
-- increased querying performance
-- good for SELECT but can make DML statements slower

-- Exercises:
-- Create a View/Table Valued Function that can get a customer's order, and what they purchased
-- Create a Stored Procedure that will Create an order, and all tracks that are associated to the order
-- Create a Stored Procedure that will Create a playlist from a list of songs