using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class HardenedGremloidium : IItem
{
    private Item _hardenedGremloidium;
    public void BuildItem()
    {
        _hardenedGremloidium = new Item();
    }

    public void BuildName()
    {
        _hardenedGremloidium.ItemName = "HardenedGremloidium";
    }

    public void BuildDescription()
    {
        _hardenedGremloidium.Description = "+5 MaxHealth for each gremloidium";
    }

    public void BuildTexture()
    {
        _hardenedGremloidium.Texture = AssetLoader.GetInstance().ITEM_ROCKCRYSTALPURPLE;
    }

    public void BuildTriggers()
    {
        var GremloidiumCount = Player.GetInstance().GetItemAmount("Gremloidium") + 
                               Player.GetInstance().GetItemAmount("HardenedGremloidium") + 1; 
        _hardenedGremloidium.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectGivePlayerMaxHealth((GremloidiumCount * 2 - 1) * 5),
            })
        };
        if (Player.GetInstance().hasItem("Gremloidium"))
        {
            _hardenedGremloidium.Triggers.Add
            (

                new Trigger(TriggerType.OnAcquire, new List<IEffect>
                {
                    new EffectIncreasePlayerAttack(((GremloidiumCount - 1) * 2 - 1) * 5),
                })
            );
        }
    }

    public Item GetItem()
    {
        return _hardenedGremloidium;
    }
}