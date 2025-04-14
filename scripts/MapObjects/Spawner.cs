using Godot;
using System;
using MartiansDutyCS.scripts.Systems;

public partial class Spawner : Node2D
{
	private PackedScene GREMLOID = GD.Load<PackedScene>("res://scenes/Entities/Gremloid.tscn");
	private Marker2D _spawnPoint;
	[Export] public int SectionNumber = 0;
	
	public override void _Ready()
	{
		_spawnPoint = GetNode<Marker2D>("SpawnPoint");
	}
	
	public void Spawn()
	{
		var newGremloid = GREMLOID.Instantiate() as Gremloid;
		newGremloid.GlobalPosition = _spawnPoint.GlobalPosition;	
		GetTree().Root.AddChild(newGremloid);
	}
	
}
