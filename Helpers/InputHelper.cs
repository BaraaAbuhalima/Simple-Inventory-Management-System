static class InputHelper
{
    public static string ReadProductName()
    {
        Console.WriteLine("Enter Product Name : ");
        return ReadString();
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
    public static int ReadChoice(int left, int right)
    {
        Console.Write($"Select an option ({left}, {right}): ");
        int x = ReadInteger();
        return x >= left && x <= right ? x : ReadChoice(left, right);
    }
    private static int ReadInteger()
    {
        try
        {
            string? input = Console.ReadLine();
            ArgumentNullException.ThrowIfNull(input);
            int number = int.Parse(input);
            return number;
        }
        catch (Exception)
        {
            Console.WriteLine("Please Enter a valid number : ");
            return ReadInteger();
        }
    }
    private static string ReadString()
    {
         string? input = Console.ReadLine();
        return (input is null) || ((input = input.Trim()) == "") ? ReadProductName() : input;
    }
}