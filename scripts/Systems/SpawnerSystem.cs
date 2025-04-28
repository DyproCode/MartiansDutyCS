using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using MartiansDutyCS.scripts.Entities;
using MartiansDutyCS.scripts.Systems;
using EventHandler = MartiansDutyCS.scripts.Systems.EventHandler;

public partial class SpawnerSystem : Node
{
	private List<Spawner> _spawners = new List<Spawner>();
	private int _currentSpawner = 0;
	private int _numEnemiesToSpawn = 0;
	private int _numEnemiesKilled = 0;
	private int _numEnemiesSpawned = 0;
	private Timer _spawnTimer = new();
	private bool _shouldSpawn = false;
	
	public override void _Ready()
	{
		EventHandler.GetInstance().Connect(EventHandler.SignalName.StartOfRound,
			new Callable(this, nameof(OnStartOfRound)));

		EventHandler.GetInstance().Connect(EventHandler.SignalName.EnemyDies, 
			new Callable(this, nameof(OnEnemyDies)));

		foreach (var spawner in GetChildren())
		{
			if (spawner is Spawner)
			{
				_spawners.Add(spawner as Spawner);
			}
		}
		
		GetTree().Root.AddChild(_spawnTimer);
		_spawnTimer.Timeout += OnTimerTimeout;
		_spawnTimer.Start(SpawnTime());
	}

	private float SpawnTime()
	{
		if (GameManager.GetInstance().GetRound() >= 10)
		{
			return 0.25f;
		}
		
		if (GameManager.GetInstance().GetRound() >= 8)
		{
			return 0.5f;
		}
		
		if (GameManager.GetInstance().GetRound() >= 5)
		{
			return 1;
		}
		
		if (GameManager.GetInstance().GetRound() >= 3)
		{
			return 1.5f;
		}
		
		return 2;
	}
	
	public void OnStartOfRound()
	{
		_shouldSpawn = true;
		_numEnemiesToSpawn = (int)Math.Round(Math.Pow(GameManager.GetInstance().GetRound(),2) * 0.50 + 6);
		_numEnemiesKilled = 0;
		_numEnemiesSpawned = 0;
	}

	public void OnEnemyDies(BaseEnemy _enemy)
	{
		if (_numEnemiesKilled == _numEnemiesToSpawn)
		{
			_shouldSpawn = false;
			EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.EndOfRound);
		}
		_numEnemiesKilled++;
	}

	private void OnTimerTimeout()
	{
		if (_shouldSpawn && _numEnemiesSpawned <= _numEnemiesToSpawn)
		{
			var spawnerNodesInRange = Player.GetInstance().GetPlayerScene().SpawnArea.GetOverlappingBodies()
				.Where(x => x.IsInGroup("Spawner"));

			List<Spawner> spawnersInRange = new();
			foreach (var spawnerNode in spawnerNodesInRange)
			{
				var spawner = spawnerNode as Spawner;
				if (GameManager.GetInstance().GetSections().Contains(spawner.SectionNumber))
				{
					spawnersInRange.Add(spawner);
				}
			}
			
			if (spawnersInRange.Count() > 0)
			{
				var randomSpawer = GD.RandRange(0, spawnersInRange.Count() - 1);
				var spawner = spawnersInRange.ToList()[randomSpawer] as Spawner;
				spawner.Spawn();
				_numEnemiesSpawned++;
			}
		}
		else
		{
			_shouldSpawn = false;
		}
		_spawnTimer.Start(SpawnTime());
	}
}
