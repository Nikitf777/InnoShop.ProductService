using InnoShop.CommonEnvironment;
using InnoShop.ProductService.Repositories;
using InnoShop.ProductService.Services;
using InnoShop.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddAuthorization()
	.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters {
		IssuerSigningKey = new SymmetricSecurityKey(Env.JwtSecretKeyBytes),
		ValidIssuer = Env.JwtKeyIssuer,
		ValidAudience = Env.JwtKeyAudience,
		ValidateIssuerSigningKey = true,
		ValidateLifetime = true,
		ValidateIssuer = true,
		ValidateAudience = true,

	});

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
