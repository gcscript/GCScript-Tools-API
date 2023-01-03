namespace GCScript_Tools_API.ViewModels;

public class RolePostViewModel
{
    public string Name { get; set; }
}

public class RolePutViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
}
