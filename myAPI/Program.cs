

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<OrderRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => // This allows other origins to request. otherwise only same origin is allowed.
{
    options.AddPolicy(name: "_RestrictedAccessToPkbrains",
    builder =>
    {
        builder.WithOrigins("https://www.Pkbrains.com");
        builder.WithMethods("Read");
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("_RestrictedAccessToPkbrains");

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
