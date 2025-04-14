using Godot;

namespace MartiansDutyCS.scripts.StatusEffects;

public partial class BurnStatus : StatusEffect
{
    private int _stacks = 0;
    public BurnStatus(Node node, int stacks) : base(node)
    {
        _stacks = stacks;
    }
    
    protected override void ApplyEffect()
    {
        if (_target.HasNode("HealthComponent"))
        {
            _target.Call("TakeDamage", _stacks * 5);
        }
    }

    public void IncreaseStacks()
    {
        _stacks++;
    }
}