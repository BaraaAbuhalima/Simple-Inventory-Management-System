using System.Diagnostics.CodeAnalysis;
class Product : Item<string>
{
    public required string Name { get; set; } 
    public override string Key => Name;
    public required int Price { get; set; }
    public required int Quantity { get; set; }
    
   [SetsRequiredMembers]
    public Product(string name, int price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    public override string ToString()
    {
        return $" Name : {Name} , Price : {Price} , Quantity : {Quantity}";
    }
} 