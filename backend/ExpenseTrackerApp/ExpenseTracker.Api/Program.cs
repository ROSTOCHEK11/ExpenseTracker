using ExpenseTracker.Application.Services;
using ExpenseTracker.Core.Models;
using ExpenseTracker.DataAccess;
using ExpenseTracker.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DB
var connectionString = builder.Configuration.GetConnectionString("local") ?? throw new InvalidOperationException("Connection string is not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserAuthService, UserAuthService>();


//Identity
builder.Services.AddIdentity<AppUserEntity, IdentityRole>().
	AddEntityFrameworkStores<AppDbContext>().
	AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequiredLength = 8;
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireUppercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.User.RequireUniqueEmail = true;
	options.SignIn.RequireConfirmedEmail = false;
	options.Lockout.MaxFailedAccessAttempts = 5;
});


// Auth and Jwt
var JWTSetting = builder.Configuration.GetSection("JWT");

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
.AddJwtBearer(options =>
{
	options.SaveToken = true;
	options.RequireHttpsMetadata = false;
	options.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidAudience = JWTSetting["ValidAudience"],
		ValidIssuer = JWTSetting["ValidIssuer"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSetting.GetSection("SecurityKey").Value!))
	};
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		In = ParameterLocation.Header,
		BearerFormat = "JWT",
		Scheme = "Bearer",
		Description = "Please enter your token with this format: 'Bearer YOUR_TOKEN'"
	});

	c.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		 {
			new OpenApiSecurityScheme
			{
				Name = "Bearer",
				Scheme = "outh2",
				In = ParameterLocation.Header,
				Reference = new OpenApiReference
				{
					Id = "Bearer",
					Type = ReferenceType.SecurityScheme
				}
			},
			new List<string>()
		 }
	});

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
