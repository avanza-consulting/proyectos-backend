namespace ProjectBff.Contracts;
public class CreateProjectRequest(string name, string clientName, short currencyId, List<ItemRequest> items)
{
    public string Name { get; set; } = name;
    public string ClientName { get; set; } = clientName;
    public short CurrencyId { get; set; } = currencyId;
    public List<ItemRequest> Items { get; set; } = items;
}

public class ItemRequest(short typeId, string name)
{
    public short TypeId { get; set; } = typeId;
    public string Name { get; set; } = name;
    public List<ItemRequest> Children { get; set; } = new List<ItemRequest>();
}

public class QuoteRequest
{
    public int ModulesCount { get; set; } = 0;
    public int ItemsCount { get; set; } = 0;
    public decimal TotalSoles { get; set; } = 0;
    public decimal TotalDollars { get; set; } = 0;
}

public class CostRequest(decimal subTotalSoles, decimal subTotalDollars, ItemRequest item, int feeId, int hoursCount)
{
    public int HoursCount { get; set; } = hoursCount;
    public decimal SubTotalSoles { get; set; } = subTotalSoles;
    public decimal SubTotalDollars { get; set; } = subTotalDollars;
    public ItemRequest Item { get; set; } = item;
    public int FeeId { get; set; } = feeId;
}


public class CreateProjectResponse(int Id, string name, string clientName, int currencyId, DateTime createdAt)
{
    public int Id { get; set; } = Id;
    public string Name { get; set; } = name;
    public string ClientName { get; set; } = clientName;
    public int CurrencyId { get; set; } = currencyId;
    public DateTime CreatedAt { get; set; } = createdAt;
}