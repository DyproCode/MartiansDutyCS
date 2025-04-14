using Godot;
using System;
using MartiansDutyCS.scripts.Systems;

public partial class GameOverScene : Node2D
{
	public override void _Ready()
	{
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
