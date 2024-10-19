using Godot;
using System;
using MartiansDutyCS.scripts.Systems;
using EventHandler = MartiansDutyCS.scripts.Systems.EventHandler;

public partial class pause_menu : Control
{

    private void _on_resume_pressed()
    {
        GetTree().Paused = false;
        Hide();
    }
    
    private void _on_quit_pressed()
    {
        EventHandler.GetInstance().Free();
        GameManager.GetInstance().Free();
        GetTree().Quit();
    }
}
