using Microsoft.EntityFrameworkCore;
using MVCTask.Models;

namespace MVCTask.DTOs;

public class OrderDto
{
    public int SelectedProductId { get; set; }
    public List<Product> Products { get; set; } 
    [Precision(18, 4)]
    public decimal SelectedProductPrice { get; set; }
}