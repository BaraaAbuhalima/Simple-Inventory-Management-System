
using System.Diagnostics.CodeAnalysis;

class Product :Item<string> {
    public required string Name
    {
        get => Key;
        set => Key = value;
    }
    public required int Price { get; set; }
    public required int Quantity{get;set;}

    [SetsRequiredMembers]
    public Product(string name, int price, int quantity)
    {
        Key = name;
        Name = name;
        Price = price;
        Quantity = quantity;
    }
} 