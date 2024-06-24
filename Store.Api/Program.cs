using MediatR;
using System.Text;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Store.Entities.Entities;
using Store.Entities.Common.Models;
using Store.Api.Common.Validator;
using Store.Api.Common.Middlewares;
using Store.Data.Persistence;
using Store.Data.Repositories.Clients;
using Store.Data.Repositories.Products;
using Store.Data.Repositories.Purchases;
using Store.Data.Repositories.BranchStores;
using Store.Business.Services.Clients;
using Store.Business.Services.Products;
using Store.Business.Services.Purchases;
using Store.Business.Services.BranchStores;
using Store.Business.Common.Services.CurrentUser;
using Microsoft.AspNetCore.Identity;
using Store.Business.Services.Auth;
using Store.Api.Common.Mapping;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins, policy  => {
        policy.WithOrigins("http://localhost:4200/",
                           "http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddControllers().AddFluentValidation(options => {
    options.ImplicitlyValidateChildProperties = true;
    options.ImplicitlyValidateRootCollectionElements = true;
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<StoreDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(option => {
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    var jwtSecret = builder.Configuration["Jwt:Secret"];

    if (string.IsNullOrEmpty(jwtSecret)) {
        throw new ArgumentNullException("Jwt:Secret", "JWT Secret Key cannot be null or empty.");
    }

    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer           = true,
        ValidateAudience         = true,
        ValidateLifetime         = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer              = builder.Configuration["Jwt:Issuer"],
        ValidAudience            = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
    };
});

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IBranchStoreService, BranchStoreService>();
builder.Services.AddScoped<IBranchStoreRepository, BranchStoreRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBranchStoreRepository, BranchStoreRepository>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPurchaseService, PurchaseService>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseDetailRepository, PurchaseDetailRepository>();
builder.Services.AddScoped(typeof(IValidatorHelper<>), typeof(ValidatorHelper<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context  = services.GetRequiredService<StoreDbContext>();

    await context.Database.MigrateAsync();
    await DataInitializer.InitializeAsync(services);
}

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();