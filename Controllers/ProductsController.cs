using System.Security.Claims;
using InnoShop.ProductService.Models;
using InnoShop.ProductService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoShop.ProductService.Controllers;

public record struct ClaimJson(string Type, string ValueType, string Value);

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductsController(IProductService productService) : ControllerBase
{
	private readonly IProductService productService = productService;

	[HttpGet]
	public async Task<IEnumerable<Product>> GetProducts(string searchQuery = "", float priceMin = 0.0f, float priceMax = float.MaxValue, bool availableOnly = true)
	{
		var userId = Convert.ToUInt32(this.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
		return await this.productService.GetProducts(userId, searchQuery, priceMin, priceMax, availableOnly);
	}
}