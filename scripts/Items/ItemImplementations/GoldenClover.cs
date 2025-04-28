using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class GoldenClover : IItem
{
    private Item _goldenClover;
    public void BuildItem()
    {
        _goldenClover = new Item();
    }

    public void BuildName()
    {
        _goldenClover.ItemName = "GoldenClover";
    }

    public void BuildDescription()
    {
        _goldenClover.Description = "Large increase to all stats";
    }

    public void BuildTexture()
    {
        _goldenClover.Texture = AssetLoader.GetInstance().ITEM_CLOVER;
    }

    public void BuildTriggers()
    {
        _goldenClover.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectGivePlayerMaxHealth(20), 
                new EffectIncreasePlayerArmour(5),
                new EffectIncreasePierce(2),
                new EffectDescreasePlayerLuck(10),
                new EffectDecreasePlayerSpeed(20),
                new EffectIncreaseCritDamage(50),
                new EffectIncreasePlayerAttack(20)
            })
        };
    }

    public Item GetItem()
    {
        return _goldenClover;
    }
}