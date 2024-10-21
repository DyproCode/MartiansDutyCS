using Godot;
using System;
using MartiansDutyCS.scripts.Systems;
using EventHandler = MartiansDutyCS.scripts.Systems.EventHandler;

public partial class ui : CanvasLayer
{
    private Control _pauseMenu;
    private Label _moneyValueLabel;
    private bool _isReady = false;
    private ItemPicker _itemPicker;
    private Label _roundLabel;

    public override void _Ready()
    {
        EventHandler.GetInstance().Connect(EventHandler.SignalName.EndOfRound,
            new Callable(this, nameof(OnEndOfRound)));
        
        _pauseMenu = GetNode<Control>("PauseMenu");
        _moneyValueLabel = GetNode<Label>("MoneyHBox/MoneyValueLabel");
        _itemPicker = GetNode<ItemPicker>("ItemPicker");
        _roundLabel = GetNode<Label>("RoundLabel");
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
        _roundLabel.Text = GameManager.GetInstance().GetRound().ToString();
    }

    public void OnEndOfRound()
    {
        _itemPicker.SetUpNewSelection();
        _itemPicker.Show();
    }
}
