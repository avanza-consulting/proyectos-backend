public interface IFees
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public short TypeId { get; set; }
    public decimal HourlyRateSoles { get; set; }
    public decimal HourlyRateDollars { get; set; }
    public DateTime? UpdatedAt { get; set; }
}