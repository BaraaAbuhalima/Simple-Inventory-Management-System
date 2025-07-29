class Program {
    static void Main(string[] args){
         Product product = new("Sample Product", 100, 10);
        ProductInventory productInventory = ProductInventory.Instance;
        Console.WriteLine(productInventory.Add(product));
        Console.WriteLine(productInventory.Size());
        Console.WriteLine(productInventory.Add(product));
        Console.WriteLine(productInventory.Size());
        Console.WriteLine("Welcome to the Simple Inventory Management System!");
    }
}