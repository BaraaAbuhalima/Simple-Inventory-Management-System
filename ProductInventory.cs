class ProductInventory : Inventory<string, Product>
{
    public static ProductInventory Instance { get; } = new();
}
