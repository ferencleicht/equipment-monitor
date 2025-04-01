using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain;

public class Equipment
{
    [Key]
    public required string Id { get; set; }
    public required string Name { get; set; }
    public State State { get; set; }
    public DateTime LastUpdated { get; set; }
}
