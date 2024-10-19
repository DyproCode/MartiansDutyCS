using Godot;
using System;
using MartiansDutyCS.scripts.Entities;
using EventHandler = MartiansDutyCS.scripts.Systems.EventHandler;

public partial class HealthComponent : Node
{
    public int MaxHealth;
    public int CurrentHealth;
    private health_bar _healthBar;

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
        _healthBar.SetHealth(CurrentHealth);
        var parent = GetParent() as BaseEnemy;
        if (CurrentHealth <= 0)
        {
            EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.EnemyDies, parent);
            GetParent().QueueFree();
        }
    }
}
