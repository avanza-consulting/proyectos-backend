using System.ComponentModel.DataAnnotations;
using ProjectBff.Utils;

namespace ProjectBff.Domain;

public class Fee(int typeId, decimal hourlyRateSoles, decimal hourlyRateDollars)
{
    public DateTime CreatedAd { get; set; } = DateTime.Now;
    [EnumDataType(typeof(Types))]
    public required int TypeId { get; set; } = typeId;
    public required decimal HourlyRateSoles { get; set; } = hourlyRateSoles;
    public required decimal HourlyRateDollars { get; set; } = hourlyRateDollars;

    public void UpdateHourlyRate(decimal hourlyRateSoles, decimal hourlyRateDollars)
    {
        HourlyRateSoles = hourlyRateSoles;
        HourlyRateDollars = hourlyRateDollars;
    }

    public void UpdateTypeId(int typeId)
    {
        TypeId = typeId;
    }

    public void AssignCreatedAt()
    {
        CreatedAd = DateTime.Now;
    }
}