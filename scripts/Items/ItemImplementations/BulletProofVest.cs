using System.Collections.Generic;
using System.Threading.Channels;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class BulletProofVest : IItem
{
    private Item _bulletProofVest;
    public void BuildItem()
    {
        _bulletProofVest = new Item();
    }

    public void BuildName()
    {
        _bulletProofVest.ItemName = "Bullet Proof Vest";
    }

    public void BuildDescription()
    {
        _bulletProofVest.Description = "+40 Health";
    }

    public void BuildTexture()
    {
        _bulletProofVest.Texture = AssetLoader.GetInstance().ITEM_CHESTPLATE;
    }

    public void BuildTriggers()
    {
        _bulletProofVest.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectGivePlayerMaxHealth(40)
            })
        };
    }

    public Item GetItem()
    {
        return _bulletProofVest;
    }
}