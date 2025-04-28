using Godot;
using System;
using MartiansDutyCS.scripts.Systems;

public partial class GameOverScene : Node2D
{
	private Label _gremloidsKilledLbl;
	private Label _roundLbl;
	
	public override void _Ready()
	{
		AudioManager.GetInstance().PlaySound("res://assets/sounds/death.wav", GetTree().CurrentScene, true, -3);
		AudioManager.GetInstance().PlaySound("res://assets/sounds/wind.wav", GetTree().CurrentScene, true, volume: -6);
		_roundLbl = GetNode<Label>("RoundAchievedLbl");
		_gremloidsKilledLbl = GetNode<Label>("GremloidsKilledLbl");
		_gremloidsKilledLbl.Text = "Gremloids Killed: " + GameManager.GetInstance().GetGremloidsKilled();
		_roundLbl.Text = "Round Achieved: " + GameManager.GetInstance().GetRound();
		
		
	}

	private void _on_try_again_btn_pressed()
	{
		GameManager.GetInstance().GameSessionData.ClearData();
		GameManager.GetInstance().ResetGame();
		Player.GetInstance().ResetPlayer();
		GetTree().ChangeSceneToFile("res://scenes/Screens/start_screen.tscn");
	}

	private void _on_quit_btn_pressed()
	{
		GameManager.GetInstance().GameSessionData.ClearData();
		GetTree().Quit();
	}
}
