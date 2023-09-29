
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add ConnectionStrings
var connection = builder.Configuration.GetConnectionString("ReDB");
builder.Services.AddDbContext<ReDbContext>(options => options.UseSqlServer(connection));

//Add Interface Injection
builder.Services.AddScoped<IRepo<Meal , MealDto>, MealHandler>();
builder.Services.AddScoped<IRepo<Catigory , CatigoryDto>, CatigoryHandler>();
builder.Services.AddScoped<IRepo<Messages, MessageDto>, MessageHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
