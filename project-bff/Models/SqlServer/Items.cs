
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBff.Models;

[Table("items")]
public class SqlServerItems : IItems
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type_id")]
    [Required]
    [EnumDataType(typeof(Types))]
    public short TypeId { get; set; }

    [Column("name")]
    [Required]
    public string? Name { get; set; }

    // [Column("parent_id")]
    // public int? ParentId { get; set; }

    [Column("children_count")]
    [DefaultValue(0)]
    public short ChildrenCount { get; set; }

    [Column("created_at")]
    [DefaultValue("CURRENT_TIMESTAMP")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey("parent_id")]
    public virtual SqlServerItems? Parent { get; set; }

    public List<SqlServerItems> Children { get; set; } = new List<SqlServerItems>();

    [ForeignKey("project_id")]
    public virtual SqlServerProjects? Project { get; set; }
}