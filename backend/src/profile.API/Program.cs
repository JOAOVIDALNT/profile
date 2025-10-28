using profile.API.Filters;
using profile.Application;
using profile.Infrastructure;
using profile.Infrastructure.Data;
using valet.lib.Auth.Service.Token.Middlewares;
using valet.lib.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringHandler()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration);

builder.Services.AddValet<AppDbContext>(builder.Configuration, options =>
{
    options.EnableValetAuth = true;
    options.EnableValetHash = true;
    options.EnableValetSwaggerGen = true;
});

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddRouting(options => options.LowercaseUrls = true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
