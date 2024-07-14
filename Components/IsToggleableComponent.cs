namespace Ship.Components;

public class IsToggleableComponent : Component
{
    public bool IsOn { get; set; }
    public IsToggleableComponent(bool initialValue = false)
    {
        IsOn = initialValue;
    }
}