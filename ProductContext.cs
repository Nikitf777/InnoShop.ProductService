using InnoShop.CommonEnvironment;
using InnoShop.ProductService.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoShop.UserService;

public class ProductContext : DbContext
{
	public DbSet<Product> Products { get; set; }

	public ProductContext()
	{
		_ = this.Database.EnsureCreated();
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		_ = optionsBuilder.UseNpgsql($"Host={Env.DbHost};Port={Env.DbPort};Database={Env.DbName};Username={Env.DbUser};Password={Env.DbPassword}");
	}
}