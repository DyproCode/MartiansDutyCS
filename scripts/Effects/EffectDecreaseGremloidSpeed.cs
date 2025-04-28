namespace MartiansDutyCS.scripts.Effects;

public class EffectDecreaseGremloidSpeed : IEffect
{
    private int _speedToDecrease = 0;

    EffectDecreaseGremloidSpeed(int speed)
    {
        _speedToDecrease = speed;
    }
    
    public void Execute()
    {
        Gremloid.Speed -= _speedToDecrease;
    }
}