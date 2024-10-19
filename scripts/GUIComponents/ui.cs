using Godot;
using System;
using MartiansDutyCS.scripts.Systems;

public partial class ui : CanvasLayer
{
    private Control _pauseMenu;
    private Label _moneyValueLabel;
    private bool _isReady = false;

    public override void _Ready()
    {
        _pauseMenu = GetNode<Control>("PauseMenu");
        _moneyValueLabel = GetNode<Label>("MoneyHBox/MoneyValueLabel");
        _isReady = true;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Escape"))
        {
            if (GetTree().Paused)
            {
                _pauseMenu.Hide();
                GetTree().Paused = false;
            }
            else
            {
                _pauseMenu.Show();   
                GetTree().Paused = true;    
            }
        }
        _moneyValueLabel.Text = Player.GetInstance().Money.ToString();
    }
}
