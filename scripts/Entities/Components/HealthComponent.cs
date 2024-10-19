using Godot;
using System;

public partial class HealthComponent : Node
{
    public int _maxHealth;
    public int _currentHealth;
    private health_bar _healthBar;

    public void Initialize(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
        _healthBar.InitializeHealthBar(_maxHealth);
    }
    public override void _Ready()
    {
        _healthBar = GetNode<health_bar>("HealthBar");
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            GetParent().QueueFree();
        }
    }
}
