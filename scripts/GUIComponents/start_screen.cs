using Godot;
using System;

public partial class start_screen : Control
{
    private void _on_start_btn_pressed()
    {
        GetTree().ChangeSceneToFile("res://scenes/Screens/main_game.tscn");
    }

    private void _on_quit_btn_pressed()
    {
        GetTree().Quit();
    }
}
