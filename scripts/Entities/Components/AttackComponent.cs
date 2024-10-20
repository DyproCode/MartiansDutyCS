using System.Linq;
using Godot;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Entities.Components;

public partial class AttackComponent : Node
{
    private RayCast2D _rayCast2D;
    private Timer _attackTimer;
    
    public override void _Ready()
    {
        _rayCast2D = GetNode<RayCast2D>("RayCast2D");
        _attackTimer = GetNode<Timer>("AttackTimer");
    }

    public override void _Process(double delta)
    {
        var player = GetTree().GetNodesInGroup("Player").First() as PlayerScene;
        if (_rayCast2D.IsColliding() && _rayCast2D.GetCollider() == player)
        {
            if (_attackTimer.IsStopped())
            {
                Attack();
            }
        }
    }

    public void Attack()
    {
        _rayCast2D.Enabled = false;
        var parent = GetParent() as BaseEnemy;
        Player.GetInstance().TakeDamage(parent!.Damage);
    }

    private void _on_attack_timer_timeout()
    {
        _rayCast2D.Enabled = true;
    }
}