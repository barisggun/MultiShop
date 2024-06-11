using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Business.Concrete;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Concrete;
using MultiShop.Cargo.DataAccess.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceCargo";
});

builder.Services.AddDbContext<CargoContext>();

builder.Services.AddScoped<ICargoCompanyDal,EfCargoCompanyDal>();
builder.Services.AddScoped<ICargoCompanyService,CargoCompanyManager>();

builder.Services.AddScoped<ICargoOperationDal,EfCargoOperationDal>();
builder.Services.AddScoped<ICargoOperationService,CargoOperationManager>();

builder.Services.AddScoped<ICargoDetailDal,EfCargoDetailDal>();
builder.Services.AddScoped<ICargoDetailService,CargoDetailManager>();

builder.Services.AddScoped<ICargoCustomerDal,EfCargoCustomerDal>();
builder.Services.AddScoped<ICargoCustomerService,CargoCustomerManager>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
