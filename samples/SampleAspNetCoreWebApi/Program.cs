var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.ConfigureSwagger("Sample ASP.NET Core Web API", "v1");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(app.Configuration);
    app.UseSwaggerUI(app.Configuration);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapRootToSwaggerUI();
app.MapControllers();

app.Run();
