using InnoShop.ProductService.Models;
using InnoShop.ProductService.Repositories;

namespace InnoShop.ProductService.Services;

public interface IProductService
{
	public Task<IEnumerable<Product>> GetProducts(string searchQuery = "", float priceMin = 0.0f, float priceMax = float.MaxValue, bool availableOnly = true);
}

public class ProductService(IProductRepository productRepository) : IProductService
{
	private readonly IProductRepository productRepository = productRepository;

	public async Task<IEnumerable<Product>> GetProducts(string searchQuery = "", float priceMin = 0.0f, float priceMax = float.MaxValue, bool availableOnly = true)
	{
		return await this.productRepository.FetchProductsAsync(searchQuery, priceMin, priceMax, availableOnly);
	}
}

