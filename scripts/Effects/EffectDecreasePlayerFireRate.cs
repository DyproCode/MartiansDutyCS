using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectDecreasePlayerFireRate : IEffect
{
    private double _fireRateDecrease;

    public EffectDecreasePlayerFireRate(double decrease)
    {
        _fireRateDecrease = decrease;
    }
    
    public void Execute()
    {
        Player.GetInstance().AttackSpeed *= _fireRateDecrease;
    }
}