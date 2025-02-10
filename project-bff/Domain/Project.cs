namespace ProjectBff.Domain;

public class Project(string name, string clientName, int currencyId)
{
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public required string Name { get; set; } = name;
    public required string ClientName { get; set; } = clientName;
    public required int CurrencyId { get; set; } = currencyId;
    public List<Item> Items { get; set; } = new List<Item>();
    // public List<Quote> Quotes { get; set; } = new List<Quote>();

    // public void AddQuote(Quote quote)
    // {
    //     Quotes.Add(quote);
    // }

    // public void RemoveQuote(Quote quote)
    // {
    //     Quotes.Remove(quote);
    // }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateClientName(string clientName)
    {
        ClientName = clientName;
    }

    public void UpdateCurrencyId(int currencyId)
    {
        CurrencyId = currencyId;
    }

    public void AssignCreatedAt()
    {
        CreatedAt = DateTime.Now;
    }
}