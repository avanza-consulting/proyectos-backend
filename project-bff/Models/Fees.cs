using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ProjectBff.Models;

[Table("fees")]
class Fees : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("type_id")]
    public int TypeId { get; set; }

    [Column("hourly_rate_soles")]
    public decimal HourlyRateSoles { get; set; }

    [Column("hourly_rate_dollars")]
    public decimal HourlyRateDollars { get; set; }

    [Column("quote_id")]
    public int QuoteId { get; set; }
}