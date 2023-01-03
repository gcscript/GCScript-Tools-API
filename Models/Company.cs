using System.Text.Json.Serialization;

namespace GCScript_Tools_API.Models;

public class Company
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Slug { get; set; }
    public string Name { get; set; }
    public byte PurchaseMargin { get; set; }
    public Guid ResponsibleId { get; set; }
    public DateTime Registered { get; set; } = DateTime.UtcNow;

    // RELATIONSHIPS
    [JsonIgnore] public User Responsible { get; set; }
    [JsonIgnore] public ICollection<Unit> Units { get; set; }
}
