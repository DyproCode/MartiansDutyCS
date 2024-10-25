using System;
using MartiansDutyCS.scripts.Systems;
using EventHandler = MartiansDutyCS.scripts.Systems.EventHandler;

namespace MartiansDutyCS.scripts.Effects;

public class EffectGivePlayerMaxHealth : IEffect
{
    private int _healthIncrease;

    public EffectGivePlayerMaxHealth(int healthIncrease)
    {
        _healthIncrease = healthIncrease;
    }
    public void Execute()
    {
        Player.GetInstance().MaxHealth += _healthIncrease;
        Player.GetInstance().CurrentHealth += _healthIncrease;
        EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.OnPlayerMaxHealthIncrease);
    }
}