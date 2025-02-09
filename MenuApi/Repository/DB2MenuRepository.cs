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
            // var connectionString = "SERVER=127.0.0.1:25000;DATABASE=mydb1;UID=test;PWD=test1234;";
            var accessToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VybmFtZSI6InRlc3QiLCJleHAiOjE3NjQ0NTk4NTUsImlzcyI6IkNvbXBhbnlYIiwiYXVkIjoieW91cmF1ZGllbmNlIn0.BD2K-Q7zlnYT_MOAHhmzm_r48RwVxqPd_qZm0fQwrCHg1WGXZmOzQ1Oc8dkdVubstiISbahnQYpP07zAlzpl1epLIFj0WAQ4CtflgMGO8FcB3zUIizEoao0-SQBDvrmqcxHf8981pP_fkiBgWlLRiCHQE2pYpmnWYvPrZCdlFn58c9itAXdGEbnE2NFKo-AUyCSdFVEIS9OC5x0xEJGE03P0veZc5RnT9E8Ih_otNsyP5HIrat17HjJZS0DxtiDp2nPu-xkcxwwE3ZgD775Mb92Lu5fkQzZu-5O1UwXZYlo6aTst3M50o6FGnCZ8A_mKKhdORssSpud5D2ai6kqm6g";
            var connectionString = "SERVER=127.0.0.1:25000;DATABASE=mydb1;AUTHENTICATION=TOKEN;ACESSTOKEN=jwr;";
            // Connect to the database
            try
            {
                DB2ConnectionStringBuilder connStringBld = new DB2ConnectionStringBuilder();
                connStringBld.Database = "SAMPLE";
                connStringBld.UserID = "Jack";
                connStringBld.Password = "BlueJays";
                connStringBld.Server = "jacksserver:db2c_DB2";
                connStringBld.Authentication = "TOKEN";
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
