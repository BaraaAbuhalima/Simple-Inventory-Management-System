class ProductInventory : Inventory<string, Product>
{
    private static readonly ProductInventory instance = new();
    public static ProductInventory Instance => instance;
    public override string ToString()
    {
        var productsList = this.All();
        string s = "";
        for (int i = 0; i < productsList.Count; i++)
        {
            s += $"{i+1}.  {productsList[i]}\n";
        }
        return s;
    }

}
