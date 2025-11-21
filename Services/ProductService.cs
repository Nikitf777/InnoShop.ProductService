using InnoShop.ProductService.Models;
using InnoShop.ProductService.Repositories;

namespace InnoShop.ProductService.Services;

public interface IProductService
{
	public Task<IEnumerable<Product>> GetProducts(uint userId, string searchQuery = "", float priceMin = 0.0f, float priceMax = float.MaxValue, bool availableOnly = true);
}

public class ProductService(IProductRepository productRepository) : IProductService
{
	private readonly IProductRepository productRepository = productRepository;

	public async Task<IEnumerable<Product>> GetProducts(uint userId, string searchQuery = "", float priceMin = 0.0f, float priceMax = float.MaxValue, bool availableOnly = true)
	{
		return await this.productRepository.FetchProductsAsync(userId, searchQuery, priceMin, priceMax, availableOnly);
	}
}

