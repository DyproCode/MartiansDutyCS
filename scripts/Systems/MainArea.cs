using Godot;
using MartiansDutyCS.scripts.Systems;

public partial class MainArea : Node2D
{
	private PlayerScene _player;
	private PackedScene _gremloidBoss = (PackedScene)GD.Load("res://scenes/Entities/gremloid_boss.tscn"); 
	
	public override void _Ready()
	{
		_player = GetNode<PlayerScene>("Player");
		
		AudioManager.GetInstance().PlaySound("res://assets/sounds/MartiansDutyCave.wav", Player.GetInstance().GetPlayerScene(), true, 3);
		EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.StartOfRound);
		EventHandler.GetInstance().Connect(EventHandler.SignalName.AllShrinesCompleted, new Callable(this, nameof(onShrinesCompleted)));
	}
	

	public override void _Process(double delta)
	{
		
	}

	private void onShrinesCompleted()
	{
		var gremloidBoss = _gremloidBoss.Instantiate() as GremloidBoss;
		gremloidBoss.GlobalPosition = new Vector2(368, 1072);
		AddChild(gremloidBoss);
	}
}
