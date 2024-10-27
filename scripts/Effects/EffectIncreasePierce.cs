using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectIncreasePierce : IEffect
{
    private int _pierceIncrease;

    public EffectIncreasePierce(int pierceIncrease)
    {
        _pierceIncrease = pierceIncrease;
    }
    
    public void Execute()
    {
        Player.GetInstance().Pierce += _pierceIncrease;
    }
}