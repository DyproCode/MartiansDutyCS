using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class FourLeafClover : IItem
{
    private Item _fourLeafClover;
    public void BuildItem()
    {
        _fourLeafClover = new Item();
    }

    public void BuildName()
    {
        _fourLeafClover.ItemName = "Four Leaf Clover";
    }

    public void BuildDescription()
    {
        _fourLeafClover.Description = "Small increase to all stats";
    }

    public void BuildTexture()
    {
        _fourLeafClover.Texture = AssetLoader.GetInstance().ITEM_CLOVER;
    }

    public void BuildTriggers()
    {
        _fourLeafClover.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectGivePlayerMaxHealth(10), 
                new EffectIncreasePlayerArmour(2),
                new EffectIncreasePierce(1),
                new EffectDescreasePlayerLuck(2),
                new EffectDecreasePlayerSpeed(10),
                new EffectIncreaseCritDamage(10),
                new EffectIncreasePlayerAttack(5)
            })
        };
    }

    public Item GetItem()
    {
        return _fourLeafClover;
    }
}