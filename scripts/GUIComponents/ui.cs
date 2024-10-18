using Godot;
using System;

public partial class ui : CanvasLayer
{
    private Control _pause_menu;

    public override void _Ready()
    {
        _pause_menu = GetNode<Control>("PauseMenu");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Escape"))
        {
            if (GetTree().Paused)
            {
                _pause_menu.Hide();
                GetTree().Paused = false;
            }
            else
            {
                _pause_menu.Show();   
                GetTree().Paused = true;    
            }
        }
    }
}
