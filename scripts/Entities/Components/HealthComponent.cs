using Godot;
using System;
using MartiansDutyCS.scripts.Entities;
using MartiansDutyCS.scripts.Systems;
using EventHandler = MartiansDutyCS.scripts.Systems.EventHandler;

public partial class HealthComponent : Node
{
    public int MaxHealth;
    public int CurrentHealth;
    public health_bar _healthBar; 
    public PackedScene deathAnim = (PackedScene)ResourceLoader.Load("res://scenes/Entities/enemy_dies.tscn");


    public void Initialize(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        _healthBar.InitializeHealthBar(MaxHealth);
    }
    public override void _Ready()
    {
        _healthBar = GetNode<health_bar>("HealthBar");
    }
    
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.OnHit);

        _healthBar.SetHealth(CurrentHealth);
        var parent = GetParent() as BaseEnemy;
        if (parent is Gremloid)
        {
            AudioManager.GetInstance().PlaySound("res://assets/sounds/goblin_hurt.wav", parent, volume: -6);
        }
        
        if (CurrentHealth <= 0)
        {
            EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.EnemyDies, parent);
            var animation = deathAnim.Instantiate() as Node2D;
            animation.GlobalPosition = parent.GlobalPosition;
            GetTree().GetCurrentScene().AddChild(animation);
            if (parent is Gremloid)
            {
                GameManager.GetInstance().IncrementGremloidsKilled();
                AudioManager.GetInstance().PlaySound("res://assets/sounds/splat.wav", animation, volume: -9);
            }
            
            GetParent().QueueFree();
        }
    }
}
