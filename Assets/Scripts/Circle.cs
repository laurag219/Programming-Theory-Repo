using UnityEngine;

// INHERITANCE
public class Circle : Shape
{
    // POLYMORPHISM
    public override string DisplayText()
    {
        return $"{Name} color {ColorName} ";
    }
}