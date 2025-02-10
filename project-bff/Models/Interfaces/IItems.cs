public interface IItems
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public short TypeId { get; set; }
    public string? Name { get; set; }
    // public int? ParentId { get; set; }
    public short ChildrenCount { get; set; }
    public DateTime? UpdatedAt { get; set; }
}