var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.MapGet("/", () => "Hello World!");

app.Run();
