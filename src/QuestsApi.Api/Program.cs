using QuestsApi.Api;
using QuestsApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.AddQuestsApi();

var app = builder.Build();
app.MapControllers();
app.UseSwagger(options => options.RouteTemplate = "api/{documentName}/swagger.json");
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/api/v1/swagger.json", "Quests API V1");
    options.RoutePrefix = "api";
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<QuestsApiDbContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

app.Run();