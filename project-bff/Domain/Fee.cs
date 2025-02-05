using System.ComponentModel.DataAnnotations;

namespace ProjectBff.Domain;

public class Fee(short typeId, decimal hourlyRateSoles, decimal hourlyRateDollars)
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [EnumDataType(typeof(Types))]
    public required short TypeId { get; set; } = typeId;
    public required decimal HourlyRateSoles { get; set; } = hourlyRateSoles;
    public required decimal HourlyRateDollars { get; set; } = hourlyRateDollars;
    public DateTime? UpdatedAt { get; set; }

    public void UpdateHourlyRate(decimal hourlyRateSoles, decimal hourlyRateDollars)
    {
        HourlyRateSoles = hourlyRateSoles;
        HourlyRateDollars = hourlyRateDollars;
    }

    public void UpdateTypeId(short typeId)
    {
        TypeId = typeId;
    }

    public void AssignCreatedAt()
    {
        CreatedAt = DateTime.Now;
    }

    public void AssignUpdatedAt()
    {
        UpdatedAt = DateTime.Now;
    }
}