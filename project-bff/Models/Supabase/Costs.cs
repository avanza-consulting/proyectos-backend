using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ProjectBff.Models;

[Table("costs")]
class SupabaseCosts : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("quote_id")]
    public int QuoteId { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("fee_id")]
    public int FeeId { get; set; }

    [Column("hours_count")]
    public int HoursCount { get; set; }

    [Column("subtotal_soles")]
    public decimal SubtotalSoles { get; set; }

    [Column("subtotal_dollars")]
    public decimal SubtotalDollars { get; set; }
}