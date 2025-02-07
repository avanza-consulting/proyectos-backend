public interface IQuotes
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public short ModulesCount { get; set; }
    public short ItemsCount { get; set; }
    // public int ProjectId { get; set; }
    public decimal TotalSoles { get; set; }
    public decimal TotalDollars { get; set; }
    public DateTime DeliveredAt { get; set; }
    public int TypeId { get; set; }
    public DateTime? UpdatedAt { get; set; }
}