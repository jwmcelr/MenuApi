namespace MenuApi.Domains.Menus
{
    public class MenuItem
    {
        public int Id { get; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MenuItem() { }

        public MenuItem(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
