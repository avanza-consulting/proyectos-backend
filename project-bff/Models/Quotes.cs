using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ProjectBff.Models;

[Table("quotes")]
class Quotes : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }

    [Column("project_id")]
    public int ProjectId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("modules_count")]
    public int ModulesCount { get; set; }

    [Column("items_count")]
    public int ItemsCount { get; set; }

    [Column("total_soles")]
    public decimal TotalSoles { get; set; }

    [Column("total_dollars")]
    public decimal TotalDollars { get; set; }

    [Column("delivered_at")]
    public DateTime DeliveredAt { get; set; }

    [Column("type_id")]
    public int TypeId { get; set; }
}
