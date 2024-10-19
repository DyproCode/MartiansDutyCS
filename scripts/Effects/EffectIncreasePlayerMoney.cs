using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectIncreasePlayerMoney : IEffect
{
    private int _amount = 0;

    public EffectIncreasePlayerMoney(int amount)
    {
        _amount = amount;
    }
    public void Execute()
    {
        Player.GetInstance().Money += _amount;
    }
}