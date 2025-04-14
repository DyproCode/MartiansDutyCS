using System.Collections.Generic;
using Godot;
using MartiansDutyCS.scripts.Entities;
using MartiansDutyCS.scripts.Systems;

public partial class SpawnerSystem : Node
{
	private List<Spawner> _spawners = new List<Spawner>();
	private int _currentSpawner = 0;
	private int _numEnemiesToSpawn = 0;
	private int _numEnemiesKilled = 0;
	private int _numEnemiesSpawned = 0;
	private Timer _spawnTimer = new Timer();
	private bool _shouldSpawn = false;
	
	public override void _Ready()
	{
		EventHandler.GetInstance().Connect(EventHandler.SignalName.StartOfRound,
			new Callable(this, nameof(OnStartOfRound)));

		EventHandler.GetInstance().Connect(EventHandler.SignalName.EnemyDies, 
			new Callable(this, nameof(OnEnemyDies)));
		
		_spawners.Add(GetNode<Spawner>("spawner_1"));
		_spawners.Add(GetNode<Spawner>("spawner_2"));
		_spawners.Add(GetNode<Spawner>("spawner_3"));
		_spawners.Add(GetNode<Spawner>("spawner_4"));
		_spawners.Add(GetNode<Spawner>("spawner_5"));
		_spawners.Add(GetNode<Spawner>("spawner_6"));
		_spawners.Add(GetNode<Spawner>("spawner_7"));
		_spawners.Add(GetNode<Spawner>("spawner_8"));
		_spawners.Add(GetNode<Spawner>("spawner_9"));
		_spawners.Add(GetNode<Spawner>("spawner_10"));
		
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
		_numEnemiesToSpawn = GameManager.GetInstance().GetRound() * 5;
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
			if (_currentSpawner < _spawners.Count
			    && _spawners[_currentSpawner].SectionNumber <= GameManager.GetInstance().GetSection())
			{
				_numEnemiesSpawned++;
				_spawners[_currentSpawner++].Spawn();
			}
			else
			{
				_currentSpawner = 0;
			}
		}
		else
		{
			_shouldSpawn = false;
		}
		_spawnTimer.Start(SpawnTime());
	}
}
