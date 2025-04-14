using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class VampRounds : IItem
{
    private Item _vampRounds;
    public void BuildItem()
    {
        _vampRounds = new Item();
    }

    public void BuildName()
    {
        _vampRounds.ItemName = "VampRounds";
    }

    public void BuildDescription()
    {
        _vampRounds.Description = "5 Health On Hit";
    }

    public void BuildTexture()
    {
        _vampRounds.Texture = AssetLoader.GetInstance().ITEM_VAMPROUNDS;
    }

    public void BuildTriggers()
    {
        _vampRounds.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnHit, new List<IEffect>
            {
                new EffectHealPlayer(5)
            })
        };
    }

    public Item GetItem()
    {
        return _vampRounds;
    }
}