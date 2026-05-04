using UnityEngine;

// INHERITANCE
public class Square : Shape
{
    // POLYMORPHISM
    public override string DisplayText()
    {
        return $"{Name} color {ColorName} ";
    }
}