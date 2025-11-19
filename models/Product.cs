namespace InnoShop.ProductService.Models;

public class Product
{
	public uint Id { get; set; }
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
	public float Price { get; set; }
	public bool IsAvailable { get; set; }
	public int UserId { get; set; }
	public DateTime CreationDate { get; set; }
}