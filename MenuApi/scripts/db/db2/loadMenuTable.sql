-- to run from DB2/Bin folder:
-- db2 -tvf "C:\work\repositories\MenuApi\MenuApi\scripts\db\db2\loadMenuTable.sql"

connect to mydb1;

INSERT INTO MENU.MENU (NAME) VALUES ('DEFAULT MENU');

