using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTask.Context;
using MVCTask.DTOs;
using MVCTask.Models;

namespace MVCTask.Controllers;

[Authorize]
public class OrderController : Controller
{
    private readonly ApplicationContext _context;

    public OrderController(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        return View(await _context.Orders.ToListAsync());
    }
    
    public IActionResult Create()
    {
        var products = _context.Products.ToList();

        var viewModel = new OrderDto    
        {
            Products = products,
        };
        
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Create([FromBody]Order order)
    {
        
        _context.Orders.Add(order);
        _context.SaveChanges();
        return Ok();
    }
    
    
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var order = await _context.Orders.FirstOrDefaultAsync(m => m.Id == id);
        
        var orderItems = _context.OrderItems.Include(o => o.Product).Where(o => o.OrderId == order.Id).ToList();
        
        order.OrderItems = orderItems;
        
        if (order == null)
        {
            return NotFound();
        }

        foreach (var orderItem in order.OrderItems)
        {
            Console.WriteLine(orderItem.OrderId);
        }
        return View(order);
    }
}