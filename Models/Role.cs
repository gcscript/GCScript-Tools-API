using System.Text.Json.Serialization;

namespace GCScript_Tools_API.Models;

public class Role
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }

    // RELATIONSHIPS
    [JsonIgnore] public ICollection<User> Users { get; set; }
}
