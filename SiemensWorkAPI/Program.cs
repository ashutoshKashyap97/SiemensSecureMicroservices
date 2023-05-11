using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SiemensWorkAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SiemensWorkAPIContext>(options =>
    options.UseInMemoryDatabase("SiemensWorks"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:7214";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });
var app = builder.Build();
SeedDataBase(app);

void SeedDataBase(WebApplication app)
{
    using(var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var worksContext = services.GetRequiredService<SiemensWorkAPIContext>();
        SiemensWorkContextSeed.SeedAsync(worksContext);
    }
}

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
