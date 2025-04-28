using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Entities;
using MartiansDutyCS.scripts.Systems;

public partial class Gremloid : BaseEnemy
{
    //Health
    public static int MaxHealth = 100;
    public static float Speed = 200;
    public static int MoneyDrop = 50;
    public NavigationAgent2D _navAgent;
    public PlayerScene _player;
    
    public override void _Ready()
    {
        MaxHealth = 50 + GameManager.GetInstance().GetRound() * 10;
        this.Damage = 18 + GameManager.GetInstance().GetRound() * 2;
        _sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _healthComponent = GetNode<HealthComponent>("HealthComponent");
        HitArea = GetNode<Area2D>("HitArea");
        _navAgent = GetNode<NavigationAgent2D>("NavAgent");
        _healthComponent.Initialize(MaxHealth);
        _player = GetTree().GetNodesInGroup("Player").FirstOrDefault() as PlayerScene;
        
        Triggers.Add(
            new Trigger(TriggerType.Die,
                new List<IEffect>
                {
                    new EffectIncreasePlayerMoney(MoneyDrop)
                }
            ));
    }

    public override void _Process(double delta)
    {
        
        //For Nav
        var dir = ToLocal(_navAgent.GetNextPathPosition()).Normalized();
        //var dir = GlobalPosition.DirectionTo(_player.GlobalPosition);
        if (_player == null)
        {
            return;
        }
        
        _sprite.LookAt(_player.GlobalPosition);
        if (State == "walking" && GlobalPosition.DistanceTo(_player.GlobalPosition) > 25)
        { 
            _navAgent.SetVelocity(dir * Speed);
        }
        else
        {
            _navAgent.SetVelocity(dir * -1);
        }
        
        SetAnimation();
        MoveAndSlide();
    }
    
    private void SetAnimation()
    {
        if (State == "walking")
        {
            if (_healthComponent.CurrentHealth <= _healthComponent.MaxHealth * 0.5)
            {
                _sprite.Animation = "walking_dying";
            }
            else if (_healthComponent.CurrentHealth < _healthComponent.MaxHealth)
            {
                _sprite.Animation = "walking_hurt";
            }
            else
            {
                _sprite.Animation = "walking_full";
            }
        }
        else if (State == "attacking")
        {
            _sprite.Animation = "attacking";
        }
    }

    private void MakePath()
    {
        _navAgent.TargetPosition = _player.GlobalPosition;
    }
    
    private void _on_targeting_timer_timeout()
    {
        MakePath();
    }

    private void _on_nav_agent_velocity_computed(Vector2 velocity)
    {
        Velocity = velocity;
    }
}
