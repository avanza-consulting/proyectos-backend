using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBff.Models;

[Table("quotes")]
class SqlServerQuotes : IQuotes
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    // [Column("project_id")]
    // public int ProjectId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("modules_count")]
    public short ModulesCount { get; set; }

    [Column("items_count")]
    public short ItemsCount { get; set; }

    [Column("total_soles")]
    public decimal TotalSoles { get; set; }

    [Column("total_dollars")]
    public decimal TotalDollars { get; set; }

    [Column("delivered_at")]
    public DateTime DeliveredAt { get; set; }

    [Column("type_id")]
    public int TypeId { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public List<SqlServerCosts> Costs { get; set; } = new List<SqlServerCosts>();
}
