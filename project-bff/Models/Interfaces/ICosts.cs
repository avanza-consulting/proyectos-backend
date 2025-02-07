public interface ICosts
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    // public int QuoteId { get; set; }
    // public int ItemId { get; set; }
    // public int FeeId { get; set; }
    public int HoursCount { get; set; }
    public decimal SubtotalSoles { get; set; }
    public decimal SubtotalDollars { get; set; }
    public DateTime? UpdatedAt { get; set; }
}