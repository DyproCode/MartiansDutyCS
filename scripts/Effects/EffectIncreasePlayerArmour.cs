using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectIncreasePlayerArmour : IEffect
{
    private int _armour;

    public EffectIncreasePlayerArmour(int armour)
    {
        _armour = armour;
    }
    
    public void Execute()
    {
        Player.GetInstance().Armour += _armour;
    }
}