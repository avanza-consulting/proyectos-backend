
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBff.Models;

[Table("fees")]
public class SqlServerFees : IFees
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("created_at")]
    [DefaultValue("CURRENT_TIMESTAMP")]
    public DateTime CreatedAt { get; set; }

    [Column("type_id")]
    public short TypeId { get; set; }

    [Column("hourly_rate_soles", TypeName = "decimal(10, 2)")]
    public decimal HourlyRateSoles { get; set; }

    [Column("hourly_rate_dollars", TypeName = "decimal(10, 2)")]
    public decimal HourlyRateDollars { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}