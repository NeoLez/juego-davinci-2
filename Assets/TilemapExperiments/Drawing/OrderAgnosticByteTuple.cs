using System;
using UnityEngine;

[Serializable] public class OrderAgnosticByteTuple
{
    [SerializeField] private byte firstElement;
    [SerializeField] private byte secondElement;

    public OrderAgnosticByteTuple(byte firstElement, byte secondElement)
    {
        this.firstElement = firstElement;
        this.secondElement = secondElement;
    }

    public override bool Equals(object obj)
    {
        return obj is OrderAgnosticByteTuple other && Equals(other);
    }

    public bool Equals(OrderAgnosticByteTuple other)
    {
        if (other == null)
            return false;

        return GetHashCode() == other.GetHashCode();
    }
    
    public override int GetHashCode()
    {
        var hash1 = firstElement.GetHashCode();
        var hash2 = secondElement.GetHashCode();
        return HashCode.Combine(Math.Min(hash1, hash2), Math.Max(hash1, hash2)); 
    }
}