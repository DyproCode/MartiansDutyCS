using System.Linq;
using MartiansDutyCS.scripts.Items;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectGivePlayerRandomItems : IEffect
{
    private int _itemAmount;

    public EffectGivePlayerRandomItems(int itemAmount = 1)
    {
        _itemAmount = itemAmount;
    }
    
    public void Execute()
    {
        for (int i = 0; i < _itemAmount; i++)
        {
            Player.GetInstance().GivePlayerItem(ItemFactory.GetInstance().CreateXItems(1).First());
        }
    }
}