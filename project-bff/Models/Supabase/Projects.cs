using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ProjectBff.Models;

[Table("projects")]
class SupabaseProjects : BaseModel
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
    public int CurrencyId { get; set; }
}
