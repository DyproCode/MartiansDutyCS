using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class Gremloidium : IItem
{
    private Item _gremloidium;
    public void BuildItem()
    {
        _gremloidium = new Item();
    }

    public void BuildName()
    {
        _gremloidium.ItemName = "Gremloidium";
    }

    public void BuildDescription()
    {
        _gremloidium.Description = "+5 damage for each gremloidium";
    }

    public void BuildTexture()
    {
        _gremloidium.Texture = AssetLoader.GetInstance().ITEM_ROCKCRYSTAL;
    }

    public void BuildTriggers()
    {
        var GremloidiumCount = Player.GetInstance().GetItemAmount("Gremloidium") + 1
            + Player.GetInstance().GetItemAmount("HardenedGremloidium"); 
        _gremloidium.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectIncreasePlayerAttack((GremloidiumCount * 2 - 1) * 5),
            })
        };
        
        if (Player.GetInstance().hasItem("HardenedGremloidium"))
        {
            _gremloidium.Triggers.Add
            (
                new Trigger(TriggerType.OnAcquire, new List<IEffect>
                {
                    new EffectGivePlayerMaxHealth(((GremloidiumCount - 1) * 2 - 1) * 5),
                })
            );
        }
    }

    public Item GetItem()
    {
        return _gremloidium;
    }
}