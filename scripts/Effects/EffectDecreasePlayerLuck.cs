using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectDescreasePlayerLuck : IEffect
{
    private int _luckDecrease;

    public EffectDescreasePlayerLuck(int luckIncrease)
    {
        _luckDecrease = luckIncrease;
    }
    
    public void Execute()
    {
        Player.GetInstance().Luck -= _luckDecrease;
    }
}