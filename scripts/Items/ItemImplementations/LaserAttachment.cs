using System.Collections.Generic;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items.ItemImplementations;

public class LaserAttachment : IItem
{
    private Item _laserAttachment;
    public void BuildItem()
    {
        _laserAttachment = new Item();
    }

    public void BuildName()
    {
        _laserAttachment.ItemName = "Laser Attachment";
    }

    public void BuildDescription()
    {
        _laserAttachment.Description = "+25% Crit Damage, +1 Pierce";
    }

    public void BuildTexture()
    {
        _laserAttachment.Texture = AssetLoader.GetInstance().ITEM_LASERATTACHMENT;
    }

    public void BuildTriggers()
    {
        _laserAttachment.Triggers = new List<Trigger>
        {
            new Trigger(TriggerType.OnAcquire, new List<IEffect>
            {
                new EffectIncreasePierce(1),
                new EffectIncreaseCritDamage(0.25)
            })
        };
    }

    public Item GetItem()
    {
        return _laserAttachment;
    }
}