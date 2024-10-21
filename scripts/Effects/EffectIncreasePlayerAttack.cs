using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectIncreasePlayerAttack : IEffect
{
    private int _damageIncrease = 0;

    public EffectIncreasePlayerAttack(int damageIncrease)
    {
        _damageIncrease = damageIncrease;
    }


    public void Execute()
    {
        Player.GetInstance().Damage += _damageIncrease;
    }
}