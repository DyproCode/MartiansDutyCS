using Godot;
using System;
using MartiansDutyCS.scripts.Systems;

public partial class PurchaseableWall : StaticBody2D
{
	private Area2D _purchaseArea;
	private PlayerScene _player;
	private Label _purchaseLabel;
	[Export] public int Price = 0;
	
	public override void _Ready()
	{
		_purchaseArea = GetNode<Area2D>("PurchaseArea");
		_player = GetParent().GetParent().GetNode<PlayerScene>("Player");
		_purchaseLabel = GetNode<Label>("PurchaseLabel");
		
		_purchaseLabel.Text = "Remove for $" + Price;
	}
	
	public override void _Process(double delta)
	{
		if (_purchaseArea.OverlapsArea(_player.HitArea) && Input.IsActionJustPressed("INTERACT") && Player.GetInstance().Money >= Price)
		{
			Player.GetInstance().Money -= Price;
			GameManager.GetInstance().IncreaseSection();
			QueueFree();
		}

		if (_purchaseArea.OverlapsArea(_player.HitArea))
		{
			_purchaseLabel.Visible = true;
		}
		else
		{
			_purchaseLabel.Visible = false;
		}
	}
}
