using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBff.Models;

[Table("projects")]
public class SqlServerProjects : IProjects
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [Required]
    public string? Name { get; set; }

    [Column("client_name")]
    [Required]
    public string? ClientName { get; set; }

    [Column("currency_id")]
    [EnumDataType(typeof(Types))]
    public short CurrencyId { get; set; }

    [Column("created_at")]
    [DefaultValue("CURRENT_TIMESTAMP")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public virtual List<SqlServerItems> Items { get; set; } = new List<SqlServerItems>();

    // public List<SqlServerQuotes> Quotes { get; set; } = new List<SqlServerQuotes>();
}
