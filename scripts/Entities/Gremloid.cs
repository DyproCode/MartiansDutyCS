using Godot;
using System;
using System.Linq;
using MartiansDutyCS.scripts.Systems;

public partial class Gremloid : CharacterBody2D
{
    //Health
    public static int MaxHealth = 5;
    public static float Speed = 150;
    public static int MoneyDrop = 5;
    
    //Godot Components 
    private AnimatedSprite2D _sprite;
    private HealthComponent _healthComponent;
    
    public override void _Ready()
    {
        _sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _healthComponent = GetNode<HealthComponent>("HealthComponent");
        _healthComponent.Initialize(MaxHealth);
    }

    public override void _Process(double delta)
    {
        var player = GetTree().GetNodesInGroup("Player").First() as PlayerScene;
        _sprite.LookAt(player.GlobalPosition);
        Velocity = GlobalPosition.DirectionTo(player.GlobalPosition) * Speed;
        MoveAndSlide();
    }
    
}
