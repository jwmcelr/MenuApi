using MenuApi.Domains.Menus;

namespace MenuApi.Repository
{
    public class BasicMenuRepository : IMenuRepository
    {

        public List<MenuItem> getMenuItems(int id)
        {
            List<MenuItem> Items = new List<MenuItem>();

            return Items;
        }

        protected virtual void fillMenu(List<MenuItem> menu)
        {
            menu.Add(new MenuItem(1, 1, "Spaghetti", "A Delicious Noodly Dish with Spaghetti Sauce and Meatballs"));

            menu.Add(new MenuItem(2, 1, "Lasagna", "A plateful of Cheesy, Meaty Deliciousness"));
        }

    }
}
