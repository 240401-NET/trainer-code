-- CREATE keyword is part of DDL("Data Definition Language") DROP, ALTER, TRUNCATE
CREATE TABLE Characters(
    name nvarchar(20),
    userClass nvarchar(10),
    age tinyint,
    hitpoints smallint,
);

-- CREATE SCHEMA dndrpg;
CREATE TABLE dndrpg.Characters(
    id int primary key IDENTITY,
    name nvarchar(20) not null,
    userClass nvarchar(10) not null,
    age tinyint,
    -- isAdmin bit, -- use bit for boolean in SQL 
    hitpoints smallint check (hitpoints > 0),
    created_on DATETIME DEFAULT getdate()
)
INSERT INTO dndrpg.Characters ([name], userClass, age, hitpoints) VALUES ('Juniper Songwriter', 'Bard', 32, 22), ('Valkor Preston', 'Paladin', 24, 50), ('Kung Lowershield', 'Fighter', 25, 20), ('"Mean-Green" Dean', 'Druid', 120, 18), ('Shrek', 'Ogre', 24, 20);
INSERT INTO dndrpg.Characters (name, userClass, hitpoints) VALUES ('Apollo', 'Warrior', 20), ('Pancakes', 'Fighter', 5), ('Steve', 'Retail', 40), ('Jane Doe', 'elf', 10);

SELECT * FROM dndrpg.Characters where age is null

-- DML("Data Manipulation Language") INSERT, UPDATE, DELETE
INSERT INTO Characters VALUES ('John Wick', 'Rogue', 35, 12);
INSERT INTO Characters VALUES ('John Wick', 'Rogue', 35, 10);
INSERT INTO Characters ([name], userClass, age, hitpoints) VALUES ('Juniper Songwriter', 'Bard', 32, 22), ('Valkor Preston', 'Paladin', 24, 50), ('Kung Lowershield', 'Fighter', 25, 20), ('"Mean-Green" Dean', 'Druid', 120, 18), ('Shrek', 'Ogre', 24, 20);
INSERT INTO Characters (name, userClass, hitpoints) VALUES ('Apollo', 'Warrior, Bard, Fighter', 20), ('Pancakes', 'Fighter', 5), ('Steve', 'Retail', 40), ('Jane Doe', 'Elf', 10);

-- DQL("Data Query Language")
SELECT * FROM Characters WHERE userClass = 'elf'
SELECT * FROM Characters WHERE age > 20 AND age < 30
SELECT name, userClass FROM Characters

-- Really nice keyword to remove duplicates
SELECT DISTINCT name, userClass FROM Characters
SELECT * FROM Characters

-- concat function is a type of function called "scalar function"
SELECT CONCAT(name, ', ', age) as name_age FROM Characters

-- Count is a type of function called "aggregate function"
SELECT Count(name) as Characters_in_20s FROM Characters where age > 20 AND age < 30

SELECT Count(userClass) as number_user_class, userClass FROM Characters GROUP BY userClass ORDER BY number_user_class

SELECT TOP 3 Count(userClass) as number_user_class, userClass FROM Characters GROUP BY userClass ORDER BY number_user_class desc
