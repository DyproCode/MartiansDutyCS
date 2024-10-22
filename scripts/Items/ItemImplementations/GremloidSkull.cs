using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class GremloidSkull : IItem
{
    private Item _gremloidSkull;
    public void BuildItem()
    {
        _gremloidSkull = new Item();
    }

    public void BuildName()
    {
        _gremloidSkull.ItemName = "Gremloid Skull";
    }

    public void BuildDescription()
    {
        _gremloidSkull.Description = "Significantly Decrease Attack Speed, +4 Attack";
    }

    public void BuildTexture()
    {
        _gremloidSkull.Texture = AssetLoader.GetInstance().ITEM_GREMLOIDSKULL;
    }

    public void BuildTriggers()
    {
        _gremloidSkull.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectIncreasePlayerAttack(4),
                new EffectDecreasePlayerFireRate(0.25)
            })
        };
    }

    public Item GetItem()
    {
        return _gremloidSkull;
    }
}