using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using MartiansDutyCS.scripts.Effects;
using MartiansDutyCS.scripts.Entities;
using MartiansDutyCS.scripts.Systems;

public partial class GremloidBoss : BaseEnemy
{
    //Health
    public static int MaxHealth = 40;
    public static float Speed = 70;
    public static int MoneyDrop = 100;

    public Area2D _threeHitRange;
    public Area2D _leftSwipeRange;
    public Area2D _rightSwipeRange;
    public Area2D _slapRange;
    
    public override void _Ready()
    {
        this.Damage = 0;
        _sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _healthComponent = GetNode<HealthComponent>("HealthComponent");

        _threeHitRange = GetNode<Area2D>("ThreeHitRange");
        _leftSwipeRange = GetNode<Area2D>("LeftSideSwipeRange");
        _rightSwipeRange = GetNode<Area2D>("RightSideSwipeRange");
        _slapRange = GetNode<Area2D>("SlapRange");
        
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
        if (State != "attacking")
        {
            Rotation = (float)Mathf.LerpAngle(Rotation, GlobalPosition.DirectionTo(player.GlobalPosition).Angle(),
                2.0f * delta);
            if (_threeHitRange.OverlapsArea(player.HitArea))
            {
                _sprite.Play("three_hit_combo");
                State = "attacking";
            }
            else if (_leftSwipeRange.OverlapsArea(player.HitArea))
            {
                _sprite.Play("left_side_swipe");
                State = "attacking";
            }
            else if (_rightSwipeRange.OverlapsArea(player.HitArea))
            {
                _sprite.Play("right_side_swipe");
                State = "attacking";
            }
            else if (_slapRange.OverlapsArea(player.HitArea))
            {
                _sprite.Play("slap");
                State = "attacking";
            }
            
        }
        
        if (State == "walking")
        { 
            Velocity = GlobalPosition.DirectionTo(player.GlobalPosition) * Speed;
        }
        else
        {
            Velocity = GlobalPosition.DirectionTo(player.GlobalPosition) * -0.1f;
        }
        
        MoveAndSlide();
    }
    
    public void _on_animated_sprite_2d_animation_finished()
    {
        if (State == "attacking")
        {
            var player = GetTree().GetNodesInGroup("Player").First() as PlayerScene;
            player!.TakeDamage(Damage);
            State = "walking";
            _sprite.Play("walking");
        }
    }

    public void SwitchState(string state)
    {
        
    }
}
