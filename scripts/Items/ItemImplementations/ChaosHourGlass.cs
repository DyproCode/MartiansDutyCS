using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class ChoasHourGlass : IItem
{
    private Item _chaosHourGlass;
    public void BuildItem()
    {
        _chaosHourGlass = new Item();
    }

    public void BuildName()
    {
        _chaosHourGlass.ItemName = "Chaos Hour Glass";
    }

    public void BuildDescription()
    {
        _chaosHourGlass.Description = "-20 speed, gremloids have -20 speed";
    }

    public void BuildTexture()
    {
        _chaosHourGlass.Texture = AssetLoader.GetInstance().ITEM_GALAXYHOURGLASS;
    }

    public void BuildTriggers()
    {
        _chaosHourGlass.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectDecreasePlayerSpeed(20),
                new EffectDecreaseGremloidSpeed(20),
            })
        };
    }

    public Item GetItem()
    {
        return _chaosHourGlass;
    }
}