using System.Collections.Generic;

namespace MartiansDutyCS.scripts.Systems;

using Godot;

public partial class EnemySpawnSystem : Node
{
    public List<Vector2> SectionOneSpawnPoints = new List<Vector2>
    {
        new (-55, -2),
        new (-45, -21),
        new (-38, 5),
        new (-20, 2)
    };

    public List<Vector2> SectionTwoSpawnPoints = new List<Vector2>
    {
        new (-42, -27),
        new (15, -9),
        new (-17, -44),
        new (27, -21), 
        new (7, -54)
    };
        
    public List<Vector2> SectionThreeSpawnPoints = new List<Vector2>
    {
        new (38, -18),
        new (41, -61),
        new (68, -25),
    };
    
    private Timer _spawnTimer;
    private PackedScene GREMLOID = GD.Load<PackedScene>("res://scenes/Entities/Gremloid.tscn");

    public override void _Ready()
    {
        _spawnTimer = new Timer();
        AddChild(_spawnTimer);
        _spawnTimer.WaitTime = 0.5;
        _spawnTimer.OneShot = true;
        _spawnTimer.Connect(Timer.SignalName.Timeout, new Callable( this, nameof(SpawnTimerTimeout)));
    }

    private void SpawnTimerTimeout()
    {   
        
    }
}