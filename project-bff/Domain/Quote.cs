namespace ProjectBff.Domain;

public class Quote(int typeId, decimal totalSoles, decimal totalDollars)
{
    public DateTime CreatedAd { get; set; } = DateTime.Now;
    public required int? ProjectId { get; set; }
    public int ModulesCount { get; set; } = 0;
    public int ItemsCount { get; set; } = 0;
    public decimal TotalSoles { get; set; } = totalSoles;
    public decimal TotalDollars { get; set; } = totalDollars;
    public DateTime? DeliveredAd { get; set; } = null;
    public required int TypeId { get; set; } = typeId;
    public List<Cost> Costs { get; set; } = new List<Cost>();

    public void AddCost(Cost cost)
    {
        Costs.Add(cost);
    }

    public void AddCosts(List<Cost> costs)
    {
        Costs.AddRange(costs);
    }

    public void RemoveCost(Cost cost)
    {
        Costs.Remove(cost);
    }

    public void UpdateDeliveryDate(DateTime deliveredAd)
    {
        DeliveredAd = deliveredAd;
    }

    public void UpdateModulesCount(int modulesCount)
    {
        ModulesCount = modulesCount;
    }

    public void UpdateItemsCount(int itemsCount)
    {
        ItemsCount = itemsCount;
    }

    public void UpdateTotal(decimal totalSoles, decimal totalDollars)
    {
        TotalSoles = totalSoles;
        TotalDollars = totalDollars;
    }

    public void CalculateTotal()
    {
        TotalSoles = Costs.Sum(c => c.SubTotalSoles);
        TotalDollars = Costs.Sum(c => c.SubTotalDollars);
    }

    public void UpdateTypeId(int typeId)
    {
        TypeId = typeId;
    }

    public void ValidateTotals()
    {
        if (TotalSoles != Costs.Sum(c => c.SubTotalSoles))
        {
            throw new Exception("Invalid total soles");
        }

        if (TotalDollars != Costs.Sum(c => c.SubTotalDollars))
        {
            throw new Exception("Invalid total dollars");
        }
    }
}