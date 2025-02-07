using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBff.Models;

[Table("costs")]
class SqlServerCosts : ICosts
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("created_at")]
    [DefaultValue("CURRENT_TIMESTAMP")]
    public DateTime CreatedAt { get; set; }

    // [Column("quote_id")]
    // public int QuoteId { get; set; }

    // [Column("item_id")]
    // public int ItemId { get; set; }

    // [Column("fee_id")]
    // public int FeeId { get; set; }

    [Column("hours_count")]
    public int HoursCount { get; set; }

    [Column("subtotal_soles")]
    public decimal SubtotalSoles { get; set; }

    [Column("subtotal_dollars")]
    public decimal SubtotalDollars { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public SqlServerItems Item { get; set; } = null!;
    public SqlServerFees Fee { get; set; } = null!;
}