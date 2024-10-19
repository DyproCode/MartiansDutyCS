using System.Collections.Generic;
using MartiansDutyCS.scripts.Effects;

namespace MartiansDutyCS.scripts.Systems;

public enum TriggerType
{
    Die
}

public class Trigger
{
    public TriggerType TriggerType;
    public List<IEffect> Effects;

    public Trigger(TriggerType type, List<IEffect> effects)
    {
        TriggerType = type;
        Effects = effects;
    }
    
    public void Execute()
    {
        foreach (var effect in Effects)
        {
            effect.Execute();
        }
    }
}