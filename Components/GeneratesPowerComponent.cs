namespace Ship.Components;

public class GeneratesPowerComponent : Component
{
    public double maxPower { get; set; }
    public double currentPower { get; set; }

    public GeneratesPowerComponent(double power)
    {
        maxPower = power;
        currentPower = 0;
    }
}