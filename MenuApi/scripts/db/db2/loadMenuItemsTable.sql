-- to run from DB2/Bin folder:
-- db2 -tvf "C:\work\repositories\MenuApi\MenuApi\scripts\db\db2\loadMenuItemsTable.sql"

connect to mydb1;

INSERT INTO MENU.MENU_ITEM (MENU_ID, NAME, DESCRIPTION) VALUES (1, 'Spaghetti', 'A Delicious Noodly Dish with Spaghetti Sauce and Meatballs');

INSERT INTO MENU.MENU_ITEM (MENU_ID, NAME, DESCRIPTION) VALUES (1, 'Lasagna', 'A plateful of Cheesy, Meaty Deliciousness');
