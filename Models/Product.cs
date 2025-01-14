namespace MVCTask.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? ImgPath { get; set; }
    public DateOnly Created { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}