using System;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectGivePlayerMaxHealth : IEffect
{
    private int _healthIncrease;

    public EffectGivePlayerMaxHealth(int healthIncrease)
    {
        _healthIncrease = _healthIncrease;
    }
    public void Execute()
    {
        Player.GetInstance().MaxHealth += _healthIncrease;
        Player.GetInstance().CurrentHealth += _healthIncrease;
    }
}