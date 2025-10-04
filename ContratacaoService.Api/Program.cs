using ContratacaoService.Core.Ports;
using ContratacaoService.Core.UseCases;
using ContratacaoService.Infra;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IContratacaoRepository, InMemoryContratacaoRepository>();
//builder.Services.AddScoped<IContratacaoService, ContratacaoService>();
builder.Services.AddScoped<ContratacaoService.Core.UseCases.IContratacaoService, ContratacaoService.Core.UseCases.ContratacaoService>();

builder.Services.AddHttpClient<IPropostaRemotePort, PropostaHttpAdapter>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5001"); 
});

var app = builder.Build();
app.UseSwagger(); app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();