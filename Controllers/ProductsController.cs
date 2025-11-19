using InnoShop.ProductService.Models;
using InnoShop.ProductService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoShop.ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController(IProductService productService)
{
	private readonly IProductService productService = productService;

	[HttpGet]
	public async Task<IEnumerable<Product>> GetProducts(string searchQuery = "", float priceMin = 0.0f, float priceMax = float.MaxValue, bool availableOnly = true)
	{
		return await this.productService.GetProducts(searchQuery, priceMin, priceMax, availableOnly);
	}
}