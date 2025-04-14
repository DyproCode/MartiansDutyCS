using Godot;

namespace MartiansDutyCS.scripts.StatusEffects;

public abstract partial class StatusEffect : Node
{
    private double _tickRate;
    private double _duration;
    private double _timeEffected;
    protected Node _target;

    public StatusEffect(Node node)
    {
        _target = node;
    }
    
    public void ApplyStatus(float delta)
    {
        _timeEffected += delta;
        if (_timeEffected >= _tickRate)
        {
            ApplyEffect();
            _timeEffected = 0;
        }
        
        _duration -= delta;
        
        if (_duration <= 0)
        {
            QueueFree();
        }
    }
    
    protected abstract void ApplyEffect();
}