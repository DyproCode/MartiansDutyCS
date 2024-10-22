using Godot;
using System;
using MartiansDutyCS.scripts.Systems;

public partial class PlayerScene : CharacterBody2D
{
	//Movement
	private string _state = "walking";
	private bool _canShoot = true;
	
	//Dash
	private const int DASH_TIME = 10;
	private int _currentDashTime;
	private Vector2 _dashDir = Vector2.Zero;
	private float _dashSpeed = 1000;
	private bool _canRoll = true;
	
	//Godot Objects
	private AnimatedSprite2D _sprite;
	private CollisionShape2D _collisionShape2D;
	private Marker2D _fireMarker;
	private Timer _fireRate;
	private Timer _rollTimer;
	private health_bar _healthBar;
	public Area2D HitArea;
	
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
		HitArea = GetNode<Area2D>("HitArea");
		
		_healthBar.InitializeHealthBar(Player.GetInstance().MaxHealth);
		_fireRate.SetWaitTime(Player.GetInstance().AttackSpeed);
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustReleased("DEBUG_INCREMENT_ROUND"))
		{
			GameManager.GetInstance().IncreaseRound();
		}

		if (_fireRate.IsStopped() && _fireRate.WaitTime != Player.GetInstance().AttackSpeed)
		{
			_fireRate.SetWaitTime(Player.GetInstance().AttackSpeed);
		}
		
		_sprite.Rotation = GetLocalMousePosition().Angle();
		_fireMarker.GlobalPosition = new Vector2((float)(GlobalPosition.X + Math.Cos(_sprite.Rotation + Math.PI / 20) * 40),
			(float)(GlobalPosition.Y + Math.Sin(_sprite.Rotation + Math.PI / 20) * 40));
		
		if (Input.IsActionJustPressed("DASH") && _canRoll)
		{
			_state = "dashing";
			_rollTimer.Start();
			_canRoll = false;
			_dashDir = Vector2.FromAngle(_sprite.Rotation);
		}

		if (Input.IsActionPressed("SHOOT") && _state != "dashing")
		{
			Shoot();
		}
		
		if (_state != "dashing")
		{
			var dir = Input.GetVector("LEFT", "RIGHT", "UP", "DOWN");
			Velocity = dir * Player.GetInstance().Speed;
		}

		if (_state == "dashing")
		{
			if (_currentDashTime <= DASH_TIME)
			{
				_currentDashTime++;
				Velocity = _dashSpeed * _dashDir;
			}
			else
			{
				_currentDashTime = 0;
				_state = "walking";
			}
		}
		
		this.SetState();
		MoveAndSlide();
	}
	
	private void SetState()
	{
		if (_state == "dashing")
		{
		}
		else if (Velocity == Vector2.Zero)
		{
			_state = "idle";
		}
		else
		{
			_state = "walking";
		}  
		_sprite.Animation = _state;
	}

	private void Shoot()
	{
		if (_canShoot)
		{
			var bulletInstance = _bulletPackedScene.Instantiate();
			var newBullet = bulletInstance as bullet;
			
			newBullet.Initialize("Enemy", Player.GetInstance().Damage, _sprite.Rotation, _fireMarker.GlobalPosition);
			
			GetTree().Root.GetNode("MainGame").AddChild(newBullet);
			_canShoot = false;
			_fireRate.Start();
		}
	}

	public void TakeDamage(int damage)
	{
		Player.GetInstance().CurrentHealth -= damage;
		_healthBar.SetHealth(Player.GetInstance().CurrentHealth);
		if (Player.GetInstance().CurrentHealth <= 0)
		{
			GetTree().Quit();
		}
	}
	
	private void _on_fire_rate_timeout()
	{
		_canShoot = true;
	}
	
	private void _on_roll_timer_timeout()
	{
		_canRoll = true;
	}
}
