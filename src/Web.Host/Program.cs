using Application;
using Store;
using Web.Host;
using Web.Host.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationExceptionFilter>();
});
builder.Services.AddOpenApi();

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddHostedService<DatabaseMigrationHostedService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();