using System.Diagnostics.CodeAnalysis;

class Product : Item<string>
{
    private string _name = "";
    public required string Name
    {
        get => _name;
        set
        {
            _name = value;
            Key = value;
        }
    }
    public required int Price { get; set; }
    public required int Quantity { get; set; }

    [SetsRequiredMembers]
    public Product(string name, int price, int quantity)
    {
        Key = name;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    public override string ToString()
    {
        return $" Name : {Name} , Pice : {Price} , Quantity : {Quantity}";
    }
} 