-- CREATE SCHEMA normalized_dndrpg

CREATE TABLE normalized_dndrpg.Characters(
    id int PRIMARY KEY IDENTITY,
    name nvarchar(20) not null,
    hitpoints smallint not null,
    age tinyint
);

CREATE TABLE normalized_dndrpg.Classes(
    id int PRIMARY KEY IDENTITY,
    name NVARCHAR(20) not null
);

Create table normalized_dndrpg.Features(
    id int PRIMARY KEY IDENTITY,
    classId int FOREIGN KEY REFERENCES normalized_dndrpg.Classes(id),
    name NVARCHAR(20) not null,
    DESCRIPTION NVARCHAR(400) not null
);

CREATE table normalized_dndrpg.CharacterClasses(
    id int PRIMARY KEY IDENTITY,
    classId int FOREIGN KEY REFERENCES normalized_dndrpg.Classes(id),
    characterId int FOREIGN KEY REFERENCES normalized_dndrpg.Characters(id),
    level int default 1
);

INSERT INTO normalized_dndrpg.Classes (name) values ('Battle Mage'), ('Barbarian'), ('Ranger'), ('Rogue'), ('Wizard'), ('NetRunner'), ('Druid')

INSERT INTO normalized_dndrpg.Characters (name, hitpoints) values ('Fatima', 2405)

INSERT INTO normalized_dndrpg.CharacterClasses (classId, characterId) values (1, 1), (5, 1)

select * from normalized_dndrpg.CharacterClasses

select * from normalized_dndrpg.Characters as c 
join normalized_dndrpg.CharacterClasses as cc on c.id = cc.characterId 
join normalized_dndrpg.Classes as cl on cl.id = cc.classId;