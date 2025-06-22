public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, string category, double price)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
        Price = price;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}, Price: ${Price:F2}";
    }
}
