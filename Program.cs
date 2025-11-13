using InnoShop.CommonEnvironment;
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

var app = builder.Build();

app.UseAuthorization();
app.UseAuthentication();

app.MapGet("/public", () => "Public endpoint!");
app.MapGet("/secured", () => "Secured endpoint!").RequireAuthorization();



app.Run();
