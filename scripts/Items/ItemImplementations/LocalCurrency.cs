using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class LocalCurrency : IItem
{
    private Item _localCurrency;
    public void BuildItem()
    {
        _localCurrency = new Item();
    }

    public void BuildName()
    {
        _localCurrency.ItemName = "Local Currency";
    }

    public void BuildDescription()
    {
        _localCurrency.Description = "+20$ on kill";
    }

    public void BuildTexture()
    {
        _localCurrency.Texture = AssetLoader.GetInstance().ITEM_GREMLOIDTEETH;
    }

    public void BuildTriggers()
    {
        _localCurrency.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.Die, new List<IEffect>
            {
                new EffectIncreasePlayerMoney(20)
            })
        };
    }

    public Item GetItem()
    {
        return _localCurrency;
    }
}