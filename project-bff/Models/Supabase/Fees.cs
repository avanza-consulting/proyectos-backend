using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ProjectBff.Models;

[Table("fees")]
public class SupabaseFees : BaseModel, IFees
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("type_id")]
    public short TypeId { get; set; }

    [Column("hourly_rate_soles")]
    public decimal HourlyRateSoles { get; set; }

    [Column("hourly_rate_dollars")]
    public decimal HourlyRateDollars { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}