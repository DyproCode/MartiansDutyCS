using Godot;
using System;

public partial class pause_menu : Control
{

    private void _on_resume_pressed()
    {
        GetTree().Paused = false;
        Hide();
    }
    
    private void _on_quit_pressed()
    {
        GetTree().Quit();
    }
}
