namespace Ship.Components;

public class ConsumesPowerComponent : Component
{
    public double maxPowerDraw { get; set; }
    public double currentPowerDraw { get; set; }
    public ConsumesPowerComponent(double power)
    {
        maxPowerDraw = power;
        currentPowerDraw = 0;
    }
}