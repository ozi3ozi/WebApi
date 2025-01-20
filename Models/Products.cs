namespace ProductsApi.Models;

public class Product
{
    public long Id { get; set; }
    public required string Nom { get; set; }
    public double Prix { get; set; }
}