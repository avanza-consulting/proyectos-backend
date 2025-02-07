public interface IProjects
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Name { get; set; }
    public string? ClientName { get; set; }
    public short CurrencyId { get; set; }
    public DateTime? UpdatedAt { get; set; }
}