using Godot;
using System;
using MartiansDutyCS.scripts.Systems;

public partial class start_screen : Control
{
	private Button _resumeButton;
	
	
	public override void _Ready()
	{
		_resumeButton = GetNode<Button>("MarginContainer/VBoxContainer/ResumeBtn");
		
		if (!GameManager.GetInstance().GameSessionData.HasSave())
		{
			_resumeButton.Disabled = true;
		}
	}
	
	private void _on_start_btn_pressed()
	{
		GameManager.GetInstance().GameSessionData.ClearData();
		GetTree().ChangeSceneToFile("res://scenes/Screens/main_game.tscn");
	}

	private void _on_arena_btn_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/Screens/arena.tscn");
	
	}
	
	private void _on_quit_btn_pressed()
	{
		GetTree().Quit();
	}

	private void _on_resume_btn_pressed()
	{
		GetTree().ChangeSceneToFile("res://scenes/Screens/main_game.tscn");
	}
}
