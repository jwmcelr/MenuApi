using MenuApi.Domains.Menus;

namespace MenuApi.Services.Menus
{
    public class BasicMenuService : IMenuService
    {
        public Menu getMenu(int menuId)
        {
            Menu menu = new Menu()
            {
                Id = menuId
            };

            fillMenu(menu);

            return menu;
        }

        private void fillMenu(Menu menu)
        {
            menu.addMenuItem(new MenuItem(1, "Spaghetti", "A Delicious Noodly Dish with Spaghetti Sauce and Meatballs"));

            menu.addMenuItem(new MenuItem(2, "Lasagna", "A plateful of Cheesy, Meaty Deliciousness"));
        }
    }
}
