public class Inventory {
    List<int> Items { get; set; }
    public int Total { get; set; }

    public Inventory(List<int> items)
    {
        this.Items = items;
        this.Total = this.Items.Sum();
    }
}