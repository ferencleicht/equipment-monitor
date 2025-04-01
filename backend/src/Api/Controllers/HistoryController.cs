using Api.Database;
using Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class HistoryController : Controller
{
    [HttpGet]
    public IEnumerable<HistoricalRecord> GetHistory([FromServices] ApplicationDbContext context)
    {
        return context.HistoricalRecords.ToList();
    }
}