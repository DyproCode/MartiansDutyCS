using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class RapidFire : IItem
{
    private Item _rapidFire;
    public void BuildItem()
    {
        _rapidFire = new Item();
    }

    public void BuildName()
    {
        _rapidFire.ItemName = "RapidFire";
    }

    public void BuildDescription()
    {
        _rapidFire.Description = "Greatly Increase Attack Speed";
    }

    public void BuildTexture()
    {
        _rapidFire.Texture = AssetLoader.GetInstance().ITEM_RAPIDFIRE;
    }

    public void BuildTriggers()
    {
        _rapidFire.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectIncreasePlayerFireRate(1.25)
            })
        };
    }

    public Item GetItem()
    {
        return _rapidFire;
    }
}