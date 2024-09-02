using Dapper;
using IBM.Data.Db2;
using MenuApi.Domains.Menus;
using System;

namespace MenuApi.Repository
{
    public class DB2MenuRepository : IMenuRepository
    {

        public List<MenuItem> getMenuItems(int menuId)
        {
            List<MenuItem> menuItems;
            // var connectionString = "Server=127.0.0.1;Port=50000;Database=mydb1;User Id=test;Password=test1234;";
            var connectionString = "SERVER=127.0.0.1:25000;DATABASE=mydb1;UID=test;PWD=test1234;";
            // Connect to the database
            try
            {
                using (var connection = new DB2Connection(connectionString))
                {
                    connection.Open();
                    // Create a query that retrieves all authors"    
                    var sql = "SELECT ID, MENU_ID as MENUID, NAME, DESCRIPTION FROM MENU.MENU_ITEM WHERE MENU_ID = " + menuId;
                    // Use the Query method to execute the query and return a list of objects
                    menuItems = connection.Query<MenuItem>(sql).ToList();
                }
            }
            catch(Exception ex)
            {
                int x = 3;
                throw ex;
            }

            return menuItems;

        }
    }
}
