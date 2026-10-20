using System.ComponentModel.DataAnnotations;

public class OrderModel
{
	[Required]
	public string? Name { get; set; }
	[Required]
	public string? Surname { get; set; }
	[Required]
	public string? City { get; set; }
	[Required]
	public int PostCode { get; set; }
	[Required]
	public string? Address { get; set; }
	[Required]
	public string? Country { get; set; }
	[Required]
	public string? PhoneNo { get; set; }

    public PaymentList PaymentList { get; set; } = null!;

	public string? CardNumber { get; set; }
	public string? ExpirationMonth { get; set; }
	public string? ExpirationYear { get; set; }
	public string? SecurityCode { get; set; }

}