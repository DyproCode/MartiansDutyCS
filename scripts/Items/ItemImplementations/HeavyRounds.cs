using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class HeavyRounds : IItem
{
    private Item _heavyRounds;
    public void BuildItem()
    {
        _heavyRounds = new Item();
    }

    public void BuildName()
    {
        _heavyRounds.ItemName = "HeavyRounds";
    }

    public void BuildDescription()
    {
        _heavyRounds.Description = "-20 speed, +20 Damage";
    }

    public void BuildTexture()
    {
        _heavyRounds.Texture = AssetLoader.GetInstance().ITEM_EXPLOSIVEROUNDS;
    }

    public void BuildTriggers()
    {
        _heavyRounds.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectDecreasePlayerSpeed(20),
                new EffectIncreasePlayerAttack(20)
            })
        };
    }

    public Item GetItem()
    {
        return _heavyRounds;
    }
}