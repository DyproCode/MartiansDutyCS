using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class GremloidEar : IItem
{
    private Item _gremloidEar;
    public void BuildItem()
    {
        _gremloidEar = new Item();
    }

    public void BuildName()
    {
        _gremloidEar.ItemName = "Gremloid Ear";
    }

    public void BuildDescription()
    {
        _gremloidEar.Description = "-2 luck, +50% crit damage";
    }

    public void BuildTexture()
    {
        _gremloidEar.Texture = AssetLoader.GetInstance().ITEM_GREMLOIDEAR;
    }

    public void BuildTriggers()
    {
        _gremloidEar.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectDescreasePlayerLuck(2),
                new EffectIncreaseCritDamage(50)
            })
        };
    }

    public Item GetItem()
    {
        return _gremloidEar;
    }
}