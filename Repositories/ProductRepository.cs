using InnoShop.ProductService.Models;
using InnoShop.UserService;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.ProductService.Repositories;

public interface IProductRepository
{
	public Task<IEnumerable<Product>> FetchProductsAsync(uint userId, string searchQuery = "", float priceMin = 0.0f, float priceMax = float.MaxValue, bool availableOnly = true);
}

public class ProductRepository(ProductContext context) : IProductRepository
{
	private readonly ProductContext context = context;

	public async Task<IEnumerable<Product>> FetchProductsAsync(uint userId, string searchQuery = "", float priceMin = 0, float priceMax = float.MaxValue, bool availableOnly = true)
	{
		return await (
			from product in this.context.Products
			where
				product.UserId == userId &&
				(product.Name.Contains(searchQuery) || product.Description.Contains(searchQuery)) && // Search by name and descriptions at the same time
				product.Price >= priceMin && product.Price <= priceMax && product.IsAvailable == availableOnly
			select product
		).ToListAsync();
	}
}

