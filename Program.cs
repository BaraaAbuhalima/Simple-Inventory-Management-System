class Program
{
    static void Main(string[] args)
    {
        ProductInventory productInventory = new();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Simple Inventory Management System");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. View all products");
            Console.WriteLine("3. Edit a product");
            Console.WriteLine("4. Delete a product");
            Console.WriteLine("5. Search for a product");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option (1-6): ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddProduct(productInventory);
                    break;
                case "2":
                    ViewAllProducts(productInventory);
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    exit = true;
                    break;
            }
        }
    }
    public static void AddProduct(ProductInventory productInventory)
    {
        string name = ProductInputHelper.ReadProductName();
        int price = ProductInputHelper.ReadProductPrice();
        int quantity = ProductInputHelper.ReadProductQuantity();
        Product product = new(name, price, quantity);
        int AddingResult = productInventory.Add(product);
        if (AddingResult == 1)
        {
            Console.WriteLine("Successfully Added");
        }
        else if (AddingResult == 0)
        {
            Console.WriteLine("Item Already Exist");
        }
        else if (AddingResult == -1)
        {
            Console.WriteLine("Error Trying to add a null item");
        }
    }
    public static void ViewAllProducts(ProductInventory productInventory)
    {
        var productsList = productInventory.All();
        if (productsList.Count == 0)
        {
            Console.WriteLine("The Product Inventory is Empty");
            return;
        }
        Console.WriteLine("Products List : \n");

        for (int i = 0; i < productsList.Count; i++)
        {
            Console.WriteLine(productsList[i]);
        }
    }
 
    


}