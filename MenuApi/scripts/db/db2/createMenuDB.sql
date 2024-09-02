-- to run from DB2/Bin folder:
-- db2 -tvf "C:\work\repositories\MenuApi\MenuApi\scripts\db\db2\createMenuDB.sql"

connect to mydb1;

-- Create Menu TABLE

-- DROP TABLE MENU;
-- DROP TABLE MENU_ITEM;

CREATE TABLE MENU (
	ID SMALLINT GENERATED ALWAYS AS IDENTITY,
	NAME VARCHAR(30)
);

-- Create Menu_Item TABLE
CREATE TABLE MENU_ITEM (
	ID SMALLINT GENERATED ALWAYS AS IDENTITY,
	NAME VARCHAR(30),
	DESCRIPTION VARCHAR(100)
);