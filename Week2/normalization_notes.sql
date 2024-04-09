-- Normalization : A Way of design guideline database structure To reduce redundancy and improve consistency
-- 1NF: No duplicate rows/records, atomic values in columns/attributes, unique identifier
-- 2NF: Has to be 1NF, no partial dependency (the columns in a table is depending on a non-key column)
    -- In order to achieve this, 
    -- 1. Get all unrelated data out of that table
    -- 2. Make sure you have a key that is only 1 column
-- 3NF: Has to be 2NF no transitive dependency
    -- In order to achieve this,
    -- You want to eliminate the data you can derive from the existing column

-- ... and more but typically people stop at 3rd.

-- References:
-- https://www.simplilearn.com/tutorials/sql-tutorial/what-is-normalization-in-sql#third_normal_form_3nf
-- https://www.dummies.com/article/technology/programming-web-design/sql/sql-first-second-and-third-normal-forms-160848/
-- https://www.youtube.com/watch?v=aAx_JoEDXQA
-- https://www.youtube.com/watch?v=xoTyrdT9SZI&list=PLLGlmW7jT-nTr1ory9o2MgsOmmx2w8FB3


-- Keys:
-- Candidate Key : set of columns that *could* be a key (ex: email address)
-- Primary Key : is a minimum set of columns that uniquely identify a record in a table
-- Foreign Key : is another record's primary key
-- Composite Key : is a key that is made up of more than 1 column (ex: first + last + phone?)

-- Referential Integrity: A foreign key must refer to a valid and existing primary key

-- Multiplicity
-- 1 to 1: person to ssn
-- 1 to Many: biological mother to children, department to employee (2 tables, and have a foriegn key in MANY table) 
-- Many to Many: library books <> patrons, doctors <> patients(2 tables for each entities, and use a join/junction table)