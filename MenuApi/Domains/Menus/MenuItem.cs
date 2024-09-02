namespace MenuApi.Domains.Menus
{
    public class MenuItem
    {
        public int Id { get; }

        public int MenuId { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MenuItem() { }

        public MenuItem(int id, int menuId, string name, string description)
        {
            this.Id = id;
            this.MenuId = menuId;
            this.Name = name;
            this.Description = description;
        }
    }
}
