using ZiggyCreatures.Caching.Fusion;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Aggiunge il supporto per i controller API
builder.Services.AddControllers();

// Configura FusionCache
builder.Services.AddFusionCache().TryWithAutoSetup();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura il routing per i controller
app.MapControllers();

await app.RunAsync();