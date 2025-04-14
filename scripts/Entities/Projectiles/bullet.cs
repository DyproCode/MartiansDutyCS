using Godot;
using System;
using System.Linq;
using MartiansDutyCS.scripts.Entities;
using MartiansDutyCS.scripts.Systems;

public partial class bullet : Area2D
{
    private const float BULLET_SPEED = 800;
    private const int MAX_RANGE = 1200;
    
    private float _distanceTraveled = 0;
    private string _target_group = "";
    private int _damage = 0;
    private int _pierce = 0;
    public void Initialize(string targetGroup, int damage, float angle, Vector2 pos)
    {
        _target_group = targetGroup;
        _damage = damage;
        Position = pos;
        Rotation = angle;
    }

    public override void _Ready()
    {
        _pierce = Player.GetInstance().Pierce;
    }

    public override void _PhysicsProcess(double delta)
    {
        var dir = Vector2.FromAngle(Rotation);

        GlobalPosition += dir * BULLET_SPEED * (float)delta;
        _distanceTraveled += BULLET_SPEED * (float)delta;

        if (_distanceTraveled > MAX_RANGE)
        {
            QueueFree();
        }
    }
    
    
    //Probably the reason that can't hit close gremloid. on_area_entered probably doesn't trigger if the thing spawns inside the area
    private void _on_area_entered(Area2D area2D)
    {
        if (area2D.GetParent() is BaseEnemy)
        {
            var parent = area2D.GetParent() as BaseEnemy;
            
            if (parent.FindChild("HealthComponent") != null)
            {
                parent.FindChild("HealthComponent").Call("TakeDamage", _damage);
            }
        }
        
        if (_pierce <= 0)
        {
            QueueFree();
        }
        
        _pierce--;
    }
}
