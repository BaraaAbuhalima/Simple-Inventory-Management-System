class ProductInventory : Inventory<string, Product>
{
    private static readonly ProductInventory instance = new();
    public static ProductInventory Instance => instance;
}
