using Godot;
using MartiansDutyCS.scripts.Systems;

public partial class MainArea : Node2D
{
	private PlayerScene _player;
	
	public override void _Ready()
	{
		_player = GetNode<PlayerScene>("Player");
		
		if (GameManager.GetInstance().GameSessionData.HasSave())
		{
			GameManager.GetInstance().GameSessionData.ReadJsonData();
			var data = GameManager.GetInstance().GameSessionData;
			_player.GlobalPosition = new Vector2(data.PlayerX, data.PlayerY);
			GameManager.GetInstance().SetRound(data.Round - 1);
			Player.GetInstance().GivePlayerItemsString(data.Items);
			Player.GetInstance().Money = data.Money;
		}
		
		EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.StartOfRound);
	}

	public override void _Process(double delta)
	{
		
	}
}
