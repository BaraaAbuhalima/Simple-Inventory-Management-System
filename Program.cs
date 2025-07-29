class Program
{
    static ProductInventory productInventory = new();
    static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Simple Inventory Management System");
            Console.WriteLine("=================================");
            List<OutputChoice> outputChoicesList = new();
            outputChoicesList.Add(new OutputChoice { Message = "Add a product", CallBack = AddProduct });
            outputChoicesList.Add(new OutputChoice { Message = "View all products", CallBack = ViewAllProducts });
            outputChoicesList.Add(new OutputChoice { Message = "Edit a product ", CallBack = EditProduct });
            outputChoicesList.Add(new OutputChoice { Message = "Delete a product", CallBack = DeleteProduct });
            outputChoicesList.Add(new OutputChoice { Message = "Search For A Product", CallBack = SearchProduct });
            OutputHelper.DisplayOutputChoices(outputChoicesList);
        }
    }
    public static void AddProduct()
    {
        string name = InputHelper.ReadProductName();
        int addingResult = 0;
        if (!productInventory.Contain(name))
        {
        int price = InputHelper.ReadProductPrice();
        int quantity = InputHelper.ReadProductQuantity();
        Product product = new(name, price, quantity);
         addingResult = productInventory.Add(product);
        }
        Console.WriteLine(addingResult == 1 ? "Successfully Added" : "Item Already Exist");
    }
    public static void ViewAllProducts()
    {
        var productsList = productInventory.All();
        if (productsList.Count == 0)
        {
            Console.WriteLine("The Product Inventory is Empty");
            return;
        }
        Console.WriteLine(productInventory);
    }

    public static void DeleteProduct()
    {
        string name = InputHelper.ReadProductName();
        bool found = productInventory.Delete(name);
        Console.WriteLine(found ? "Successfully Deleted" : "No product has been found with this name ");
    }
    public static void SearchProduct()
    {
        string name = InputHelper.ReadProductName();
        Product? product = productInventory.Search(name);
        Console.WriteLine(product == null ? "No Product Has Been Found With This name" : product);
    }
     public static void EditProduct()
    {
        string name = InputHelper.ReadProductName();
        Product ?product = productInventory.Search(name);
        if (product == null)
        {
            Console.WriteLine("No Product has Been found with this name");
            return;
        }

        List<OutputChoice> outputChoicesList = new();
        outputChoicesList.Add(new OutputChoice
        {
            Message = "Price",
            CallBack = () =>
            {
                  product.Price = InputHelper.ReadProductPrice();
            }
        });

        outputChoicesList.Add(new OutputChoice
        {
            Message = "Quantity",
            CallBack = () =>
            {
                  product.Quantity = InputHelper.ReadProductQuantity();
            }
        });

        outputChoicesList.Add(new OutputChoice
        {
            Message = "Both Price and Quantity",
            CallBack = () =>
            {
                product.Price = InputHelper.ReadProductPrice();
                product.Quantity = InputHelper.ReadProductQuantity();
            }
        });

        outputChoicesList.Add(new OutputChoice { Message = "Cancel / Exit", CallBack = () => { } });

        OutputHelper.DisplayOutputChoices(outputChoicesList);
    }
}