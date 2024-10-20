using System.Collections.Generic;
using Godot;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Entities;

public partial class BaseEnemy : CharacterBody2D
{
    protected AnimatedSprite2D _sprite;
    protected HealthComponent _healthComponent;
    public List<Trigger> Triggers = new List<Trigger>();
    public int Damage = 0;
    public string State = "walking";

}