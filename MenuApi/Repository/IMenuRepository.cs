using MenuApi.Domains.Menus;

namespace MenuApi.Repository
{
    public interface IMenuRepository
    {

        public List<MenuItem> getMenuItems(int menuId);
    }
}
