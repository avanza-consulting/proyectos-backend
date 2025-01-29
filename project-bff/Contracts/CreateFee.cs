namespace ProjectBff.Contracts;

public class CreateFeeRequest(int typeId, decimal hourlyRateSoles, decimal hourlyRateDollars)
{
    public required int TypeId { get; set; } = typeId;
    public required decimal HourlyRateSoles { get; set; } = hourlyRateSoles;
    public required decimal HourlyRateDollars { get; set; } = hourlyRateDollars;
}

public class CreateFeeResponse(int Id, DateTime createdAt)
{
    public int Id { get; set; } = Id;
    public DateTime CreatedAt { get; set; } = createdAt;
}