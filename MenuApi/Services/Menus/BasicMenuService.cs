using MenuApi.Domains.Menus;
using System.Net.Http;
using static MenuApi.Services.Menus.BasicMenuService;

namespace MenuApi.Services.Menus
{
    public class BasicMenuService : IMenuService
    { 

        private static HttpClient sharedClient = new()
        {
            // BaseAddress = new Uri("https://my-json-server.typicode.com/znsio/specmatic-documentation/"),

            BaseAddress = new Uri("http://localhost:9000/"),
        };

        

        public record class Pet(
            int? Id = null,
            string? name = null,
            string? type = null,
            string? status = null);

        public record class Pets(
            List<Pet> pets = null);

        public async Task<Menu> getMenu(int menuId)
        {
            Menu menu = new Menu()
            {
                Id = menuId
            };

            await fillMenu(menu);

            return menu;
        }

        protected async virtual Task fillMenu(Menu menu)
        {
            menu.addMenuItem(new MenuItem(1, "Spaghetti", "A Delicious Noodly Dish with Spaghetti Sauce and Meatballs"));

            menu.addMenuItem(new MenuItem(2, "Lasagna", "A plateful of Cheesy, Meaty Deliciousness"));

            // Strange cuisine
            var pets = await getPets();
            menu.addMenuItem(new MenuItem(3, "Dog", pets[0].type ?? "Sold out"));
        }

        private async Task<List<Pet>> getPets()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync("pets/1");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            Pet pet = System.Text.Json.JsonSerializer.Deserialize<Pet>(jsonResponse);
            List<Pet> pets = new List<Pet> { pet };


            return pets;

        } 
    }
}
