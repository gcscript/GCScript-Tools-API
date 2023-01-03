using System.Text.Json.Serialization;

namespace GCScript_Tools_API.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime Registered { get; set; } = DateTime.UtcNow;
    public Guid RoleId { get; set; } = Guid.Parse("3403C3BE-3DDF-43D6-8C2A-C02ADDA47BE4");

    [JsonIgnore] public Role Role { get; set; }
    [JsonIgnore] public IEnumerable<Company> CompanyResponsibles { get; set; }
}
