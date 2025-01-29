namespace ProjectBff.Domain;

public class Project(string name, string clientName, int currencyId)
{
    public DateTime CreatedAd { get; set; } = DateTime.Now;
    public required string Name { get; set; } = name;
    public required string ClientName { get; set; } = clientName;
    public required int CurrencyId { get; set; } = currencyId;
    public List<Quote> Quotes { get; set; } = new List<Quote>();

    public void AddQuote(Quote quote)
    {
        Quotes.Add(quote);
    }

    public void RemoveQuote(Quote quote)
    {
        Quotes.Remove(quote);
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
}