## ON UPDATE

ON UPDATE:

-To add cascading on update when you are already deleting, change the constraint in the table to:
-FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID) ON DELETE CASCADE ON UPDATE CASCADE
-Ex: UPDATE Authors SET AuthorID = 1 WHERE AuthorID = 2; \*Both the Book and Author table would
now reflect AuthorId = 2

If migrating:
\*Does not automatically support this statement, have to do it manually

1. Make sure db schema supports 'ON UPDATE CASCADE'
2. If not, in dbContext class add the sql statement:
   migrationBuilder.Sql("ALTER TABLE Books DROP CONSTRAINT IF EXISTS FK_Books_Authors_AuthorID");
   migrationBuilder.Sql("ALTER TABLE Books ADD CONSTRAINT FK_Books_Authors_AuthorID FOREIGN KEY (AuthorID)
   REFERENCES Authors(AuthorID) ON DELETE CASCADE ON UPDATE CASCADE");
   3.Run migration

If ON UPDATE is not specified, and AuthorId was changed in Author table, you would get SQL error when queried
\*Shouldn't be an issue because cascading statements are done when declaring table constraints, which are usually
type IDENTITY, and wouldn't need to be updated
