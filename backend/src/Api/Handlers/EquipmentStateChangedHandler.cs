using Api.Database;
using Api.Domain;
using Api.Interfaces;
using Api.Messages;

namespace Api.Handlers;

public class EquipmentStateChangedHandler : IMessageHandler<EquipmentStateChanged>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<EquipmentStateChangedHandler> _logger;

    public EquipmentStateChangedHandler(ILogger<EquipmentStateChangedHandler> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public Task HandleAsync(EquipmentStateChanged message)
    {
        var equipment = _dbContext.Equipments.FirstOrDefault(e => e.Id == message.EquipmentId);

        if (equipment == null)
        {
            _logger.LogWarning("Equipment with id {EquipmentId} not found", message.EquipmentId);
            return Task.CompletedTask;
        }

        var previousState = equipment.State;
        equipment.State = message.State;
        equipment.LastUpdated = DateTime.UtcNow;
        
        _dbContext.Equipments.Update(equipment);
        
        var historicalRecord = new HistoricalRecord
        {
            EquipmentId = equipment.Id,
            EquipmentName = equipment.Name,
            PreviousState = previousState,
            NewState = message.State,
            ChangedAt = DateTime.UtcNow
        };
        
        _dbContext.HistoricalRecords.Add(historicalRecord);
        
        _dbContext.SaveChanges();

        _logger.LogInformation("Equipment {EquipmentId} state changed to {State}", message.EquipmentId, message.State);

        return Task.CompletedTask;
    }
}
