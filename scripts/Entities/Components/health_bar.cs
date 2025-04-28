using Godot;
using System;

public partial class health_bar : ProgressBar
{
    private Timer _timer;
    public ProgressBar _damageBar;
    private int _health;

    public override void _Ready()
    {
        _timer = GetNode<Timer>("Timer");
        _damageBar = GetNode<ProgressBar>("DamageBar");
    }
    
    public void SetHealth(int newHealth)
    {
        var previousHealth = _health;
        _health = Math.Min((int)MaxValue, newHealth);
        Value = _health;

        if (_health < previousHealth)
        {
            _timer.Start();
        }
        else
        {
            _damageBar.Value = _health;
        }
    }

    public void SetMaxHealth(int newMaxHealth)
    {
        MaxValue = newMaxHealth;
        _damageBar.MaxValue = MaxValue;
    }

    public void InitializeHealthBar(int entityHealth)
    {
        _health = entityHealth;
        MaxValue = entityHealth;
        Value = entityHealth;
        _damageBar.MaxValue = entityHealth;
        _damageBar.Value = entityHealth;
    }
    
    private void _on_timer_timeout()
    {
        _damageBar.Value = _health;
    }
    
}
