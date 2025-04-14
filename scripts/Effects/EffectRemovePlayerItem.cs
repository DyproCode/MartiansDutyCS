using MartiansDutyCS.scripts.Items;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectRemovePlayerItem : IEffect
{
    private string _item;

    public EffectRemovePlayerItem(string item)
    {
        _item = item;
    }


    public void Execute()
    {
        Player.GetInstance().RemovePlayerItem(_item);
    }
}