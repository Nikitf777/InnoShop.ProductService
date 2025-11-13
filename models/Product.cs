namespace InnoShop.ProductService.Models;

public class Product
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
	public int Price { get; set; }
	public bool IsAccessible { get; set; }
	public int UserId { get; set; }
	public DateTime CreationDate { get; set; }
}