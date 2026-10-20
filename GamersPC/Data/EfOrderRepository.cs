


using efcoreApp.Data;

public class EfOrderRepository : IOrderRepository
{
    private IdentityContext _context;
    public EfOrderRepository(IdentityContext context)
    {
        _context = context;
    }
    public IQueryable<Order> Orders => _context.Orders;

    public void SaveOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
    }
}