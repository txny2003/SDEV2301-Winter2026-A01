namespace StateManagementDemo.Services
{
    public class CartState
    {
        public List<string> Items { get; } = new();

        public void Add(string item) => Items.Add(item);
    }
}
