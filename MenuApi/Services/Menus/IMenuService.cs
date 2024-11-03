

using MenuApi.Domains.Menus;

namespace MenuApi.Services.Menus
{
    public interface IMenuService
    {

        Task<Menu> getMenu(int id);

    }
}
