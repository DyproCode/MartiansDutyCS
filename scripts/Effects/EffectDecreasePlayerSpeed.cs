using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectDecreasePlayerSpeed : IEffect
{
    private int _speedDecrease;

    public EffectDecreasePlayerSpeed(int speedDecrease)
    {
        _speedDecrease = speedDecrease;
    }


    public void Execute()
    {
        Player.GetInstance().Speed -= _speedDecrease;
    }
}