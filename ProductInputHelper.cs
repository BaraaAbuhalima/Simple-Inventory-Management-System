static class  ProductInputHelper{
    public static string ReadProductName()
    {
        Console.WriteLine("Enter Product Name : ");
        string? input = Console.ReadLine();
        string name;
        return (input is null) || ((name = input.Trim()) == "") ? ReadProductName() : name;
    }
    private static int ReadInteger()
    {
        try
        {
            string? input = Console.ReadLine();
            int number = int.Parse(input);
            return number;
        }
        catch (Exception)
        {
            Console.WriteLine("Please Enter a valid number : ");
            return ReadInteger();
        }
    }
    public static int ReadProductPrice()
    {
        Console.WriteLine("Please Enter The Price : ");
        return ReadInteger();
    }
     public static int ReadProductQuantity()
    {
        Console.WriteLine("Please Enter The Quantity : ");
        return ReadInteger();
    }
}