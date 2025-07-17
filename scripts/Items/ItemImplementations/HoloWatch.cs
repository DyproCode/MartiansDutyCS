using System.Collections.Generic;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class HoloWatch : IItem
{
    private Item _holoWatch;
    public void BuildItem()
    {
        _holoWatch = new Item();
    }

    public void BuildName()
    {
        _holoWatch.ItemName = "Holo Watch";
    }

    public void BuildDescription()
    {
        _holoWatch.Description = "+25% Crit Damage, Slight Attack Speed Increase";
    }

    public void BuildTexture()
    {
        _holoWatch.Texture = AssetLoader.GetInstance().ITEM_HOLOWATCH;
    }

    public void BuildTriggers()
    {
        _holoWatch.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectIncreasePlayerFireRate(1.125),
                new EffectIncreaseCritDamage(0.25)
            })
        };
    }

    public Item GetItem()
    {
        return _holoWatch;
    }
}