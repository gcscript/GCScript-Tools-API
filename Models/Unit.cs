using System.Text.Json.Serialization;

namespace GCScript_Tools_API.Models;

public class Unit
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Slug { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string CNPJ { get; set; }
    public DateTime Registered { get; set; } = DateTime.UtcNow;
    public Guid CompanyId { get; set; }
    public Guid OperatorId { get; set; }

    // RELATIONSHIPS
    [JsonIgnore] public Company Company { get; set; }
    [JsonIgnore] public Operator Operator { get; set; }
}
