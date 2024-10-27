using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectIncreaseSpeed : IEffect
{
    private int _speedIncrease;
    
    public EffectIncreaseSpeed(int speedIncrease)
    {
        _speedIncrease = speedIncrease;
    }
    
    
    public void Execute()
    {
        Player.GetInstance().Speed += _speedIncrease;
    }
}