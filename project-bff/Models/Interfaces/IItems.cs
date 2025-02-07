public interface IItems
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public short TypeId { get; set; }
    public int QuoteId { get; set; }
    public string? Name { get; set; }
    public int? ParentId { get; set; }
    public short ChildrenCount { get; set; }

    public decimal TotalSoles { get; set; }

    public decimal TotalDollars { get; set; }
    public DateTime? UpdatedAt { get; set; }
}