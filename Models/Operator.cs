using System.Text.Json.Serialization;

namespace GCScript_Tools_API.Models;

public class Operator
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Slug { get; set; }
    public string UF { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string Site { get; set; }
    public DateTime Registered { get; set; } = DateTime.UtcNow;

    // RELATIONSHIPS
    [JsonIgnore] public ICollection<Unit> Units { get; set; }
}
