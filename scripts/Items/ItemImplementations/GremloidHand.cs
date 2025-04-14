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
        _gremloidHand.ItemName = "GremloidHand";
    }

    public void BuildDescription()
    {
        _gremloidHand.Description = "+4 Luck";
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
                new EffectIncreaseLuck(4)
            })
        };
    }

    public Item GetItem()
    {
        return _gremloidHand;
    }
}