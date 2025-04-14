using System.Collections.Generic;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class GremloidFoot : IItem
{
    private Item _gremloidFoot;
    public void BuildItem()
    {
        _gremloidFoot = new Item();
    }

    public void BuildName()
    {
        _gremloidFoot.ItemName = "GremloidFoot";
    }

    public void BuildDescription()
    {
        _gremloidFoot.Description = "Speed +20, Luck +2";
    }

    public void BuildTexture()
    {
        _gremloidFoot.Texture = AssetLoader.GetInstance().ITEM_GREMLOIDFOOT;
    }

    public void BuildTriggers()
    {
        _gremloidFoot.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectIncreaseSpeed(20),
                new EffectIncreaseLuck(2)
            })
        };
    }

    public Item GetItem()
    {
        return _gremloidFoot;
    }
}