using System.ComponentModel.DataAnnotations;
using ProjectBff.Utils;

namespace ProjectBff.Domain;

public class Item(int typeId, string name)
{
    public DateTime CreatedAd { get; set; } = DateTime.Now;
    [EnumDataType(typeof(Types))]
    public required int TypeId { get; set; } = typeId;
    public required string Name { get; set; } = name;
    public int ChildrenCount { get; set; } = 0;
    public decimal TotalSoles { get; set; } = 0;
    public decimal TotalDollars { get; set; } = 0;
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

    public void AddTotal(decimal totalSoles, decimal totalDollars)
    {
        TotalSoles += totalSoles;
        TotalDollars += totalDollars;
    }

    public void RemoveTotal(decimal totalSoles, decimal totalDollars)
    {
        TotalSoles -= totalSoles;
        TotalDollars -= totalDollars;
    }

    public void UpdateTotal(decimal totalSoles, decimal totalDollars)
    {
        TotalSoles = totalSoles;
        TotalDollars = totalDollars;
    }

    public void CalculateTotal()
    {
        TotalSoles = Children.Sum(c => c.TotalSoles);
        TotalDollars = Children.Sum(c => c.TotalDollars);
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
}