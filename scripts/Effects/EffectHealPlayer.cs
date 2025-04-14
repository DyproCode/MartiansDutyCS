using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectHealPlayer : IEffect
{
    private int _healAmount = 0;

    public EffectHealPlayer(int healAmount)
    {
        _healAmount = healAmount;
    }
    
    public void Execute()
    {
        if (Player.GetInstance().CurrentHealth + _healAmount >= Player.GetInstance().MaxHealth)
        {
            Player.GetInstance().CurrentHealth = Player.GetInstance().MaxHealth;
        }
        else
        {
            Player.GetInstance().CurrentHealth += _healAmount;
        }
    }
}