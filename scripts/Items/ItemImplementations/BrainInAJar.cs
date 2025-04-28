using System.Collections.Generic;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class BrainInAJar : IItem
{
    private Item _brainInAJar;
    public void BuildItem()
    {
        _brainInAJar = new Item();
    }

    public void BuildName()
    {
        _brainInAJar.ItemName = "BrainInAJar";
    }

    public void BuildDescription()
    {
        _brainInAJar.Description = "Speed +20, Luck +2";
    }

    public void BuildTexture()
    {
        _brainInAJar.Texture = AssetLoader.GetInstance().ITEM_BRAINJAR;
    }

    public void BuildTriggers()
    {
        _brainInAJar.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectIncreaseSpeed(20),
                new EffectIncreaseLuck(2)
            })
        };
    }

    public Item GetItem()
    {
        return _brainInAJar;
    }
}