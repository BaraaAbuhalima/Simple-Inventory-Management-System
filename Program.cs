class Program
{
   private static readonly ProductInventory ProductInventory = new();
    private static void Main(string[] args)
    {
        var exit = false;
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
            outputChoicesList.Add(new OutputChoice { Message = "Exit", CallBack = () => { Exit(ref exit); } });
            OutputHelper.DisplayOutputChoices(outputChoicesList);
        }
    }

    private static void Exit(ref bool exit)
    {
        exit = true;
    }
    private static void AddProduct()
    {
        var name = InputHelper.ReadProductName();
        var addingResult = false;
        if (!ProductInventory.Contain(name))
        {
            var price = InputHelper.ReadProductPrice();
            var quantity = InputHelper.ReadProductQuantity();
            var product = new Product(name, price, quantity);
             addingResult = ProductInventory.Add(product);
        }
        Console.WriteLine(addingResult  ? "Successfully Added" : "Item Already Exist");
    }
    private static void ViewAllProducts()
    {
        var productsList = ProductInventory.All();
        if (productsList.Count == 0)
        {
            Console.WriteLine("The Product Inventory is Empty");
            return;
        }
        Console.WriteLine(ProductInventory);
    }

    private static void DeleteProduct()
    {
        var name = InputHelper.ReadProductName();
        var found = ProductInventory.Delete(name);
        Console.WriteLine(found ? "Successfully Deleted" : "No product has been found with this name ");
    }
    private static void SearchProduct()
    {
        var name = InputHelper.ReadProductName();
        var product = ProductInventory.Search(name);
        Console.WriteLine(product == null ? "No Product Has Been Found With This name" : product);
    }
     private static void EditProduct()
    {
        var name = InputHelper.ReadProductName();
        var product = ProductInventory.Search(name);
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