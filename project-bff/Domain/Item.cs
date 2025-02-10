using System.ComponentModel.DataAnnotations;

namespace ProjectBff.Domain;

public class Item(int typeId, string name)
{
    [EnumDataType(typeof(Types))]
    public required int TypeId { get; set; } = typeId;
    public required string Name { get; set; } = name;
    public int ChildrenCount { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public Project? Project { get; set; }
    public Item? Parent { get; set; }
    public List<Item> Children { get; set; } = new List<Item>();

    public void AddChild()
    {
        ChildrenCount++;
    }

    public void RemoveChild()
    {
        ChildrenCount--;
    }

    public void UpdateChildrenCount(int childrenCount)
    {
        ChildrenCount = childrenCount;
    }

    public void CalculateChildrenCount()
    {
        ChildrenCount = Children.Count;
    }

    public void UpdateTypeId(int typeId)
    {
        TypeId = typeId;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void AddChild(Item child)
    {
        Children.Add(child);
    }

    public void RemoveChild(Item child)
    {
        Children.Remove(child);
    }

    public void UpdateChildren(List<Item> children)
    {
        Children = children;
    }

    public void AddChildren(List<Item> children)
    {
        Children.AddRange(children);
    }

    public void AssignCreatedAt()
    {
        CreatedAt = DateTime.Now;
    }

    public void AssignUpdatedAt()
    {
        UpdatedAt = DateTime.Now;
    }

    public void AssignProject(Project project)
    {
        Project = project;
    }

    public void AssignParent(Item parent)
    {
        Parent = parent;
    }
}