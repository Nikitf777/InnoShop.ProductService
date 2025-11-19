using InnoShop.ProductService.Models;
using InnoShop.UserService;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.ProductService.Repositories;

public interface IProductRepository
{
	public Task<IEnumerable<Product>> FetchProductsAsync(string searchQuery = "", float priceMin = 0.0f, float priceMax = float.MaxValue, bool availableOnly = true);
}

public class ProductRepository(ProductContext context) : IProductRepository
{
	private readonly ProductContext context = context;

	public async Task<IEnumerable<Product>> FetchProductsAsync(string searchQuery = "", float priceMin = 0, float priceMax = float.MaxValue, bool availableOnly = true)
	{
		return await (
			from product in this.context.Products
			where
				(product.Name.Contains(searchQuery) || product.Description.Contains(searchQuery)) &&
				product.Price >= priceMin && product.Price <= priceMax && product.IsAvailable == availableOnly
			select product
		).ToListAsync();
	}
}

