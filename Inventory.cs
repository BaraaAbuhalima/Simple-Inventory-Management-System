using System.Diagnostics;
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
    public List<T> All()
    {
        return InventoryTree.Values.ToList();

    }
    public int Size()
    {
        return InventoryTree.Count;
    }
    public void Edit(K Key, T item)
    {
        if (InventoryTree.ContainsKey(Key))
        {
            InventoryTree[Key] = item;
        }

    }
    public bool Delete(K Key)
    {
        return InventoryTree.Remove(Key);
    }
    public bool Delete(T item)
    {
        return InventoryTree.Remove(item.Key);
    }
    public virtual T? Search(K Key)
    {
        return InventoryTree.TryGetValue(Key, out T? value) ? value : null;

    }
    public bool Contain(K Key)
    {
        return InventoryTree.ContainsKey(Key);
    }
}