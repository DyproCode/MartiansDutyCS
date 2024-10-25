using System.Linq;
using Godot;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Entities.Components;

public partial class AttackComponent : Node
{
    private Area2D _area2D;
    private Timer _attackTimer;
    private Timer _bufferTimer;
    private BaseEnemy _parent;
    private PlayerScene _target;
    
    public override void _Ready()
    {
        _parent = GetParent() as BaseEnemy;
        _area2D = GetNode<Area2D>("Area2D");
        _attackTimer = GetNode<Timer>("AttackTimer");
        _bufferTimer = GetNode<Timer>("AttackBufferTimer");
        
        _target = GetTree().GetNodesInGroup("Player").First() as PlayerScene;
    }

    public override void _Process(double delta)
    {
        
        if (_area2D.OverlapsArea(_target.HitArea) && _attackTimer.IsStopped())
        {
               _bufferTimer.Start();
               _attackTimer.Start();
               _parent.State = "attacking";
        }
    }

    public void Attack()
    {
        _target.TakeDamage(_parent!.Damage);
    }

    private void _on_attack_timer_timeout()
    {
        _parent.State = "walking";
    }

    private void _on_attack_buffer_timer_timeout()
    {
        if (_area2D.OverlapsArea(_target.HitArea))
        {
            Attack();
        }
        else
        {
            _parent.State = "walking";
        }
    }
}