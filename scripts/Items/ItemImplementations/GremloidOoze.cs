using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class GremloidOoze : IItem
{
    private Item _gremloidOoze;
    public void BuildItem()
    {
        _gremloidOoze = new Item();
    }

    public void BuildName()
    {
        _gremloidOoze.ItemName = "GremloidOoze";
    }

    public void BuildDescription()
    {
        _gremloidOoze.Description = "+20 Max Health. At the end of the round, heal for 20hp";
    }

    public void BuildTexture()
    {
        _gremloidOoze.Texture = AssetLoader.GetInstance().ITEM_OOZEDIGLET;
    }

    public void BuildTriggers()
    {
        _gremloidOoze.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnEndOfRound, new List<IEffect>
            {
                new EffectHealPlayer(20)
            }),
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectGivePlayerMaxHealth(20)
            })
        };
    }

    public Item GetItem()
    {
        return _gremloidOoze;
    }
}