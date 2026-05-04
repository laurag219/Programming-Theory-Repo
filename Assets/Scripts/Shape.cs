using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] private string shapeName;
    [SerializeField] private Color shapeColor = Color.white;
    [SerializeField] private string colorName = "Blanco";

    public string Name
    {
        get { return shapeName; }
        set { shapeName = value; }
    }

    public Color Color
    {
        get { return shapeColor; }
        set
        {
            shapeColor = value;
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
                rend.material.color = value;
        }
    }

    public string ColorName
    {
        get { return colorName; }
        set { colorName = value; }
    }

    // ABSTRACTION
    private void OnMouseDown()
    {
        string message = DisplayText(); // POLYMORPHISM
        UIMessageHandler.Instance?.ShowMessage(message);
    }

    // POLYMORPHISM
    public abstract string DisplayText();

    protected virtual void Start()
    {
        Color = shapeColor;
        if (string.IsNullOrEmpty(shapeName))
            Name = gameObject.name;
        if (string.IsNullOrEmpty(colorName))
            ColorName = "Sin color";
    }
}