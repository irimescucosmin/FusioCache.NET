using FusionCache.NET.Models;
using Microsoft.AspNetCore.Mvc;
using ZiggyCreatures.Caching.Fusion;

namespace FusionCache.NET.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class FusionCacheController(IFusionCache fusionCache, IConfiguration configuration) : ControllerBase
{
    private const string TODO_PATH = "/todos";  // Percorso per ottenere i "To-Do" dall'API esterna
    private const string CACHE_KEY = "cache_todos";  // Chiave di cache per memorizzare i dati dei "To-Do"
    private const string URI_KEY = "TCode";  // Chiave di configurazione per l'URL dell'API esterna
    
    // Inizializzazione di un oggetto HttpClient per effettuare chiamate HTTP
    private readonly HttpClient _httpClient = new HttpClient
    {
        // Imposta l'URL di base dell'API esterna, ottenuto dalla configurazione
        BaseAddress = new Uri(configuration.GetValue<string>(URI_KEY) ?? string.Empty)
    };
    
    // Metodo per sincronizzare i dati nella cache (esegue una chiamata HTTP e aggiorna la cache)
    [HttpGet]
    public async Task<IActionResult> SyncCache(CancellationToken cancellationToken)
    {
        var todosResponseMessage = await _httpClient.GetAsync(TODO_PATH, cancellationToken);

        var response = await todosResponseMessage.Content.ReadFromJsonAsync<IList<ToDoModel>>(cancellationToken);
        
        return Ok(await fusionCache.GetOrSetAsync(CACHE_KEY, response, token: cancellationToken));
    }
    
    // Metodo per recuperare i dati dalla cache, se disponibili
    [HttpGet]
    public async Task<IActionResult> CacheData(CancellationToken cancellationToken)
    {
        return Ok(await fusionCache.GetOrDefaultAsync<IList<ToDoModel>>(CACHE_KEY, token: cancellationToken));
    }
    
    // Metodo per recuperare i dati direttamente dall'API esterna, senza utilizzare la cache
    [HttpGet]
    public async Task<IActionResult> NoCacheData(CancellationToken cancellationToken)
    {
        var todosResponseMessage = await _httpClient.GetAsync(TODO_PATH, cancellationToken);

        return Ok(await todosResponseMessage.Content.ReadFromJsonAsync<IList<ToDoModel>>(cancellationToken));
    }
}