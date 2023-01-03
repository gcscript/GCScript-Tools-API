namespace GCScript_Tools_API.ViewModels;

public class CompanyPostViewModel
{
    public string Name { get; set; }
    public byte PurchaseMargin { get; set; }
    public Guid ResponsibleId { get; set; }
}

public class CompanyPutViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public byte PurchaseMargin { get; set; }
    public Guid ResponsibleId { get; set; }
}
