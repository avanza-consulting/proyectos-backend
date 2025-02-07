
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBff.Models;

[Table("items")]
public class SqlServerItems : IItems
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("type_id")]
    public short TypeId { get; set; }

    [Column("quote_id")]
    public int QuoteId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("parent_id")]
    public int? ParentId { get; set; }

    [Column("children_count")]
    public short ChildrenCount { get; set; }

    [Column("total_soles")]
    public decimal TotalSoles { get; set; }

    [Column("total_dollars")]
    public decimal TotalDollars { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}