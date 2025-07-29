
abstract class Inventory<K, T> where K : notnull where T : Item<K>
{
    private readonly SortedDictionary<K, T> InventoryTree;
    public Inventory()
    {
        InventoryTree = [];

    }
    public int Add(T item)
    {

        try
        {
            ArgumentNullException.ThrowIfNull(item);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return (int)InventoryAddItem.Failed;
        }
        if (InventoryTree.ContainsKey(item.Key))
        {
            return (int)InventoryAddItem.AlreadyExists;
        }
        InventoryTree.Add(item.Key, item);
        return (int)InventoryAddItem.Success;
    }
    public int Size()
    {
        return InventoryTree.Count;
    }

}