using System.Collections.Generic;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class InterestOrb : IItem
{
    private Item _interestOrb;
    public void BuildItem()
    {
        _interestOrb = new Item();
    }

    public void BuildName()
    {
        _interestOrb.ItemName = "InterestOrb";
    }

    public void BuildDescription()
    {
        _interestOrb.Description = "Start of round gain 5% of you money as interest";
    }

    public void BuildTexture()
    {
        _interestOrb.Texture = AssetLoader.GetInstance().ITEM_ORB;
    }

    public void BuildTriggers()
    {
        _interestOrb.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnEndOfRound, new List<IEffect>
            {
                new EffectIncreasePlayerMoney("Interest", 0.05)
            })
        };
    }

    public Item GetItem()
    {
        return _interestOrb;
    }
}