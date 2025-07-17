namespace MartiansDutyCS.scripts.Effects;

public class EffectDecreaseGremloidSpeed : IEffect
{
    private int _speedToDecrease = 0;

    public EffectDecreaseGremloidSpeed(int speed)
    {
        _speedToDecrease = speed;
    }
    
    public void Execute()
    {
        if (Gremloid.Speed > 100)
        {
            Gremloid.Speed -= _speedToDecrease;
        }
    }
}