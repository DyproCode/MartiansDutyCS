using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectIncreasePlayerFireRate : IEffect
{
    private double _fireRateIncrease;

    public EffectIncreasePlayerFireRate(double increase)
    {
        _fireRateIncrease = increase;
    }
    
    public void Execute()
    {
        Player.GetInstance().AttackSpeed -= _fireRateIncrease;
    }
}