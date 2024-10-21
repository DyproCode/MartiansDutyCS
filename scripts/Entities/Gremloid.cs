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
    public static int MaxHealth = 5;
    public static float Speed = 150;
    public static int MoneyDrop = 5;
    
    public override void _Ready()
    {
        this.Damage = 1;
        _sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _healthComponent = GetNode<HealthComponent>("HealthComponent");
        _healthComponent.Initialize(MaxHealth);
        
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
        var player = GetTree().GetNodesInGroup("Player").First() as PlayerScene;
        _sprite.LookAt(player.GlobalPosition);
        if (State == "walking" && GlobalPosition.DistanceTo(player.GlobalPosition) > 10)
        { 
            Velocity = GlobalPosition.DirectionTo(player.GlobalPosition) * Speed;
        }
        else
        {
            Velocity = GlobalPosition.DirectionTo(player.GlobalPosition) * -1;
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
}
