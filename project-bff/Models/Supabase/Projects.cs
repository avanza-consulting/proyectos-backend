using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ProjectBff.Models;

[Table("projects")]
class SupabaseProjects : BaseModel, IProjects
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("client_name")]
    public string? ClientName { get; set; }

    [Column("currency_id")]
    public short CurrencyId { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}
