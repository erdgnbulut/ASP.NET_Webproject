using efcoreApp.Data;

public class Order
 {
     public int Id { get; set; }
     public string? OrderNumber { get; set; }
     
     public string? Name { get; set; }
     
     public string? Surname { get; set; }
     
     public string? City { get; set; }
     
     public int? PostCode { get; set; }
    
     public string? Address { get; set; }
    
     public string? Country { get; set; }
     public string? PhoneNo { get; set; }
     public  List<OrderItem> OrderItems { get; set; } = new();

 }
 public class OrderItem
 {
     public int Id { get; set; }
     public int OrderId { get; set; }
     public  Order Order { get; set; } = null!;
     public float? Price { get; set; }

     public int GameId { get; set; }
     public  Game Game { get; set; } = null!;
 }