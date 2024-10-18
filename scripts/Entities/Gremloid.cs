using Godot;
using System;

public partial class Gremloid : CharacterBody2D
{
    //Health
    public static int MaxHealth;
    private int _currentHealth;
    
    //Godot Components 
    private health_bar _healthBar;
    private AnimatedSprite2D _sprite;
    
    public override void _Ready()
    {
        _healthBar = GetNode<health_bar>("HealthBar");
        _healthBar.InitializeHealthBar(MaxHealth);    
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthBar.SetHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            GetTree().Quit();
        }
    }
}
