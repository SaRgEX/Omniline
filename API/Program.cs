using Application.Extensions;
using Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.ConfigurePersistence(configuration);
builder.Services.ConfigureApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
       .AllowAnyHeader()
       .AllowAnyMethod();
});
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
