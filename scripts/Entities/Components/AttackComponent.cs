using System.Linq;
using Godot;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Entities.Components;

public partial class AttackComponent : Node
{
    private Area2D _area2D;
    private Timer _attackTimer;
    private BaseEnemy _parent;
    private PlayerScene _target;
    
    public override void _Ready()
    {
        _parent = GetParent() as BaseEnemy;
        _area2D = GetNode<Area2D>("Area2D");
        _attackTimer = GetNode<Timer>("AttackTimer");
        
        _target = GetTree().GetNodesInGroup("Player").First() as PlayerScene;
        _attackTimer.SetWaitTime(1);
    }

    public override void _Process(double delta)
    {
        
        if (_area2D.OverlapsBody(_target) && _attackTimer.IsStopped())
        {
                Attack();
        }
    }

    public void Attack()
    {
        _attackTimer.Start();
        _parent.State = "attacking";
        _target.TakeDamage(_parent!.Damage);
    }

    private void _on_attack_timer_timeout()
    {
        _parent.State = "walking";
    }
}