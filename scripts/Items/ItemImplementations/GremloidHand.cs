using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class GremloidHand : IItem
{
    private Item _gremloidHand;
    public void BuildItem()
    {
        _gremloidHand = new Item();
    }

    public void BuildName()
    {
        _gremloidHand.ItemName = "Gremloid Hand";
    }

    public void BuildDescription()
    {
        _gremloidHand.Description = "+2 Luck, slightly Increase attack speed";
    }

    public void BuildTexture()
    {
        _gremloidHand.Texture = AssetLoader.GetInstance().ITEM_GREMLOIDHAND;
    }

    public void BuildTriggers()
    {
        _gremloidHand.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectIncreaseLuck(4),
                new EffectIncreasePlayerFireRate(1.125)
            })
        };
    }

    public Item GetItem()
    {
        return _gremloidHand;
    }
}