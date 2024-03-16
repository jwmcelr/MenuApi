namespace MenuApi.Domains.Menus
{
    /// <summary>
    /// Represents a Restaurant Menu
    /// </summary>
    public class Menu
    {

        public int Id { get; init; }
        public List<MenuItem> Items { get; set; }
        public Menu()
        {
            this.Items = new List<MenuItem>();
        }

        public void addMenuItem(MenuItem item)
        {
            this.Items.Add(item);
        }
    }
}
