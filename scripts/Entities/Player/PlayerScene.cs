using Godot;
using System;
using MartiansDutyCS.scripts.Entities;
using MartiansDutyCS.scripts.Entities.Player.PlayerStates;
using MartiansDutyCS.scripts.Systems;
using EventHandler = MartiansDutyCS.scripts.Systems.EventHandler;

public partial class PlayerScene : CharacterBody2D
{
	public IState State = null;
	private WalkingState _walkingState;
	private IdleState _idleState;
	private DashingState _dashingState;
	private KnockBackState _knockBackState;
	
	private bool _canShoot = true;
	public bool _canRoll = true;
	public Camera2D Camera2D;
	
	//Godot Objects
	public AnimatedSprite2D _sprite;
	private CollisionShape2D _collisionShape2D;
	private Marker2D _fireMarker;
	private Timer _fireRate;
	public Timer _rollTimer;
	private health_bar _healthBar;
	public Area2D HitArea;
	public Area2D SpawnArea;
	
	//PackedScenes
	private PackedScene _bulletPackedScene = (PackedScene)GD.Load("res://scenes/Entities/Projectiles/bullet.tscn"); 
	
	public override void _Ready()
	{
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
		_fireRate = GetNode<Timer>("FireRate");
		_rollTimer = GetNode<Timer>("RollTimer");
		_fireMarker = GetNode<Marker2D>("FireMarker");
		_healthBar = GetNode<health_bar>("HealthBar");
		SpawnArea = GetNode<Area2D>("SpawnArea");
		Camera2D = GetNode<Camera2D>("Camera2D");
		
		HitArea = GetNode<Area2D>("HitArea");

		_idleState = GetNode<IdleState>("States/PlayerIdle"); 
		_walkingState = GetNode<WalkingState>("States/PlayerWalking");
		_dashingState = GetNode<DashingState>("States/PlayerDashing");
		_knockBackState = GetNode<KnockBackState>("States/PlayerKnockback");
		
		_healthBar.InitializeHealthBar(Player.GetInstance().MaxHealth);
		_fireRate.SetWaitTime(Player.GetInstance().AttackSpeed);

		EventHandler.GetInstance().
			Connect(EventHandler.SignalName.OnPlayerMaxHealthIncrease, new Callable(this, nameof(OnMaxHealthIncrease)));
		
		EventHandler.GetInstance().
			Connect(EventHandler.SignalName.OnPlayerHeal, new Callable(this, nameof(OnHeal)));
		
		EventHandler.GetInstance()
			.Connect(EventHandler.SignalName.StartOfRound, new Callable(this, nameof(OnStartOfRound)));
		
		State = _idleState;
		
		Player.GetInstance().SetPlayerScene(this);
	}

	public override void _Process(double delta)
	{
		if (_fireRate.IsStopped() && _fireRate.WaitTime != Player.GetInstance().AttackSpeed)
		{
			_fireRate.SetWaitTime(Player.GetInstance().AttackSpeed);
		}
		
		
		_sprite.Rotation = GetLocalMousePosition().Angle();
		_fireMarker.GlobalPosition = new Vector2((float)(GlobalPosition.X + Math.Cos(_sprite.Rotation + Math.PI / 20) * 30),
			(float)(GlobalPosition.Y + Math.Sin(_sprite.Rotation + Math.PI / 20) * 30));
		
		State.PhysicsUpdate();
		State.Update();
		
		MoveAndSlide();
	}
	
	public void Shoot()
	{
		if (_canShoot)
		{
			var bulletInstance = _bulletPackedScene.Instantiate();
			var newBullet = bulletInstance as bullet;

			int critChance = GD.RandRange(1, 10);
			int damage = Player.GetInstance().Damage;
			if (critChance <= Player.GetInstance().Luck)
			{
				damage = (int)(damage * Player.GetInstance().CritDamage);
			}
			
			newBullet.Initialize("Enemy", damage, _sprite.Rotation, _fireMarker.GlobalPosition);
			
			GetTree().GetCurrentScene().AddChild(newBullet);
			_canShoot = false;
			_fireRate.Start();
			AudioManager.GetInstance().PlaySound("res://assets/sounds/Laser_Shoot.wav", this, volume: -9);
		}
	}

	public void TakeDamage(int damage)
	{
		var damageToPlayer = damage - Player.GetInstance().Armour > 0 ? damage - Player.GetInstance().Armour : 0;
		Player.GetInstance().CurrentHealth -= damageToPlayer;
		_healthBar.SetHealth(Player.GetInstance().CurrentHealth);
		if (Player.GetInstance().CurrentHealth <= 0)
		{
			GetTree().ChangeSceneToFile("res://scenes/Screens/game_over_scene.tscn");
		}
	}
	
	private void _on_fire_rate_timeout()
	{
		_canShoot = true;
	}
	
	public void SwitchState(string state)
	{
		State.Exit();
		if (state == "walking")
		{
			State = _walkingState;
		}
		else if (state == "dashing")
		{
			State = _dashingState;
		}
		else if (state == "idle")
		{
			State = _idleState;
		}
		else if (state == "knockback")
		{
			State = _knockBackState;
		}
		State.Enter();
	}

	public void _on_roll_timer_timeout()
	{
		_canRoll = true;
	}

	//Fix this
	private void OnMaxHealthIncrease()
	{
		_healthBar.SetMaxHealth(Player.GetInstance().MaxHealth);
	}

	private void OnHeal()
	{
		_healthBar.SetHealth(Player.GetInstance().CurrentHealth);
	}

	private void OnStartOfRound()
	{
		//GameManager.GetInstance().GameSessionData.SaveJsonData(Player.GetInstance().GetItemNames(), Player.GetInstance().Money, GameManager.GetInstance().GetRound(), GlobalPosition.X, GlobalPosition.Y, GameManager.GetInstance().GetSections());
	}
}
