using System.Linq;
using Godot;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Entities.Components;

public partial class AttackComponent : Node
{
    private RayCast2D _rayCast2D;
    private Timer _attackTimer;
    private BaseEnemy _parent;
    private PlayerScene _target;
    
    public override void _Ready()
    {
        _parent = GetParent() as BaseEnemy;
        _rayCast2D = GetNode<RayCast2D>("RayCast2D");
        _attackTimer = GetNode<Timer>("AttackTimer");
        
        _target = GetTree().GetNodesInGroup("Player").First() as PlayerScene;
        _attackTimer.SetWaitTime(0.5);
    }

    public override void _Process(double delta)
    {
        if (_rayCast2D.IsColliding() && _rayCast2D.GetCollider() == _target)
        {
            if (_attackTimer.IsStopped())
            {
                Attack();
            }
        }
    }

    public void Attack()
    {
        _attackTimer.Start();
        _parent.State = "attacking";
        _rayCast2D.Enabled = false;
        _target.TakeDamage(_parent!.Damage);
    }

    private void _on_attack_timer_timeout()
    {
        _parent.State = "walking";
        _rayCast2D.Enabled = true;
    }
}