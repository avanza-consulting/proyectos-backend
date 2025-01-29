namespace ProjectBff.Domain;

public class Cost(Item item, int feeId, int hoursCount, decimal subTotalSoles, decimal subTotalDollars)
{
    public DateTime CreatedAd { get; set; }
    public int? ItemId { get; set; }
    public int FeeId { get; set; } = feeId;
    public int HoursCount { get; set; } = hoursCount;
    public decimal SubTotalSoles { get; set; } = subTotalSoles;
    public decimal SubTotalDollars { get; set; } = subTotalDollars;
    public Item Item { get; set; } = item;

    public void UpdateHoursCount(int hoursCount)
    {
        HoursCount = hoursCount;
    }

    public void UpdateSubTotal(decimal subTotalSoles, decimal subTotalDollars)
    {
        SubTotalSoles = subTotalSoles;
        SubTotalDollars = subTotalDollars;
    }

    public void UpdateItem(Item item)
    {
        Item = item;
    }

    public void UpdateFee(int feeId)
    {
        FeeId = feeId;
    }

    public void ValidateSubTotals()
    {
        // if (SubTotalSoles != _initialFee.HourlyRateSoles * HoursCount)
        // {
        //     throw new Exception("Invalid sub total soles");
        // }

        // if (SubTotalDollars != _initialFee.HourlyRateDollars * HoursCount)
        // {
        //     throw new Exception("Invalid sub total dollars");
        // }
    }
}