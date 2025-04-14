using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class SyringeClamp : IItem
{
    private Item _syringeClamp;
    public void BuildItem()
    {
        _syringeClamp = new Item();
    }

    public void BuildName()
    {
        _syringeClamp.ItemName = "SyringeClamp";
    }

    public void BuildDescription()
    {
        _syringeClamp.Description = "+2 Damage";
    }

    public void BuildTexture()
    {
        _syringeClamp.Texture = AssetLoader.GetInstance().ITEM_SYRINGECLAMP;
    }

    public void BuildTriggers()
    {
        _syringeClamp.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectIncreasePlayerAttack(20)
            })
        };
    }

    public Item GetItem()
    {
        return _syringeClamp;
    }
}