using APIPessoa.Core.Service;
using APIPessoa.Data.Infra.Repository;
using APIPessoa.Core.Interface;
using APIPessoa.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>  //filtro globaL, todas as controllers
{
    options.Filters.Add<LogResultFilter>();
    options.Filters.Add<GenerateExceptionFilter>();
    options.Filters.Add<ValidateCpfActionFilter>();
    
    }
);

// metodos que tem autorização e action é para Get

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<GenerateProductActionFilter>(); // servicefilter

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
