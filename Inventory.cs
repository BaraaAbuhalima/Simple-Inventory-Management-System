using System.Diagnostics;
using System.Text;

abstract class Inventory<TKey, TValue> where TKey: notnull where TValue: Item<TKey>
{
    private readonly SortedDictionary<TKey, TValue> _inventoryTree=[];
    public bool  Add(TValue value)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(value);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        return _inventoryTree.TryAdd(value.Key, value);
         
    }
    public List<TValue> All()
    {
        return _inventoryTree.Values.ToList();

    }
    public int Size()
    {
        return _inventoryTree.Count;
    }
    public void Edit(TKey key, TValue value)
    {
        if (_inventoryTree.ContainsKey(key))
        {
            _inventoryTree[key] = value;
        }

    }
    public bool Delete(TKey key)
    {
        return _inventoryTree.Remove(key);
    }
    public bool Delete(TValue value)
    {
        return _inventoryTree.Remove(value.Key);
    }
    public TValue? Search(TKey key)
    {
        return _inventoryTree.GetValueOrDefault(key);

    }
    public bool Contain(TKey key)
    {
        return _inventoryTree.ContainsKey(key);
    }
    public override string ToString()
    {
        var arr = this.All();
        var s = new StringBuilder("");
        for (var i = 0; i < arr.Count; i++)
        {
            s.AppendLine($"{i + 1}.  {arr[i]}");
        }
        return s.ToString();
    }
}