namespace MVCTask.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public DateOnly Created { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public virtual ICollection<OrderItem>? OrderItems { get; set; } = [];
}