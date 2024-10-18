using Godot;
using System;
using System.Linq;

public partial class bullet : Area2D
{
    private const float BULLET_SPEED = 800;
    private const int MAX_RANGE = 1200;
    
    private float _distanceTraveled = 0;
    private string _target_group = "";
    private int _damage = 0;
    public void Initialize(string targetGroup, int damage, float angle, Vector2 pos)
    {
        _target_group = targetGroup;
        _damage = damage;
        Position = pos;
        Rotation = angle;
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

    private void _on_body_entered(Node2D body)
    {
        if (body.GetGroups().Count(g => g == _target_group) > 0)
        {
            QueueFree();
            if (body.HasMethod("TakeDamage"))
            {
                body.Call("TakeDamage", _damage);
            }
        }
    }
}
