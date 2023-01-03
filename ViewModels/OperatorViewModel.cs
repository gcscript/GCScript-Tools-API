namespace GCScript_Tools_API.ViewModels;

public class OperatorPostViewModel
{
    public string Name { get; set; }
    public string UF { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string Site { get; set; }
}

public class OperatorPutViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string UF { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string Site { get; set; }
}
