using Api.Database;
using Api.Domain;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class EquipmentsController : Controller
{
    [HttpGet]
    public IEnumerable<Equipment> GetEquipments([FromServices] ApplicationDbContext context)
    {
        return context.Equipments.ToList();
    }
}

