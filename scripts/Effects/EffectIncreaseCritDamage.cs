using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectIncreaseCritDamage : IEffect
{
    private double _cdIncrease;

    public EffectIncreaseCritDamage(double critIncrease)
    {
        _cdIncrease = critIncrease;
    }
    
    public void Execute()
    {
        Player.GetInstance().CritDamage += _cdIncrease;
    }
}