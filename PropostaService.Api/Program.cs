using PropostaService.Core.Ports;
using PropostaService.Core.UseCases;
using PropostaService.Infra;
using PropostaService.Infra.InMemory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPropostaRepository, InMemoryPropostaRepository>();
builder.Services.AddScoped<PropostaService.Core.UseCases.IPropostaService, PropostaService.Core.UseCases.PropostaService>();

var app = builder.Build();
app.UseSwagger(); app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

