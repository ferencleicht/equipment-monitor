using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain;

public class HistoricalRecord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public required string EquipmentId { get; set; }
    public required string EquipmentName { get; set; }
    public State PreviousState { get; set; }
    public State NewState { get; set; }
    public DateTime ChangedAt { get; set; }
}

