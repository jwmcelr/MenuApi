using MenuApi.Domains.Menus;
using MenuApi.Repository;

namespace MenuApi.Services.Menus
{
    public class DBDrivenMenuService: IMenuService
    {

        IMenuRepository _menuRepository;

        public DBDrivenMenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public Menu getMenu(int menuId)
        {
            Menu menu = new Menu()
            {
                Id = menuId
            };

            FillMenu(menu);

            return menu;
        }

        protected virtual void FillMenu(Menu menu)
        {
            List<MenuItem> menuItemList = _menuRepository.getMenuItems(menu.Id);

            menuItemList.ForEach(item => menu.addMenuItem(item));
        }
    }
}
