using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable] public class DrawingPattern
{
    [SerializeReference] private HashSet<OrderAgnosticByteTuple> uniqueLines;
    [SerializeField] private float a;

    public DrawingPattern()
    {
        uniqueLines = new();
    }

    public DrawingPattern(List<OrderAgnosticByteTuple> lines)
    {
        uniqueLines = lines.ToHashSet();
    }
    
    public void AddLine(OrderAgnosticByteTuple line)
    {
        uniqueLines.Add(line);
    }

    public bool Matches(DrawingPattern pattern)
    {
        return pattern.uniqueLines.SetEquals(uniqueLines);
    }

    public override int GetHashCode()
    {
        return uniqueLines.GetHashCode();
    }
}