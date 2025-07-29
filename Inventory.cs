
class Inventory<K,T> where K : notnull where T :Item<K>{
    private SortedDictionary<K, T> productsTree;
    public Inventory() {
            productsTree = new SortedDictionary<K, T>();
           
    }

}