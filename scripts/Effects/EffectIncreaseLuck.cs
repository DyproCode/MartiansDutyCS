using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectIncreaseLuck : IEffect
{
    private int _luckIncrease;

    public EffectIncreaseLuck(int luckIncrease)
    {
        _luckIncrease = luckIncrease;
    }
    
    public void Execute()
    {
        Player.GetInstance().Luck += _luckIncrease;
    }
}