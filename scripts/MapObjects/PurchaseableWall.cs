using Godot;
using System;
using MartiansDutyCS.scripts.Systems;

public partial class PurchaseableWall : StaticBody2D
{
	private Area2D _purchaseArea;
	private PlayerScene _player;
	private Label _purchaseLabel;
	[Export] public int Price = 0;
	[Export] public int Section;
	
	public override void _Ready()
	{
		_purchaseArea = GetNode<Area2D>("PurchaseArea");
		_player = GetParent().GetParent().GetNode<PlayerScene>("Player");
		_purchaseLabel = GetNode<Label>("PurchaseLabel");
		
		_purchaseLabel.Text = "Remove for $" + Price;
	}
	
	public override void _Process(double delta)
	{
		if (_purchaseArea.OverlapsArea(_player.HitArea) && Input.IsActionJustPressed("INTERACT"))
		{
			if (Player.GetInstance().Money >= Price)
			{
				Player.GetInstance().Money -= Price;
				GameManager.GetInstance().UnlockSection(Section);
				AudioManager.GetInstance().PlaySound("res://assets/sounds/purchase.wav", GetTree().CurrentScene);
				QueueFree();
			}
			else
			{
				AudioManager.GetInstance().PlaySound("res://assets/sounds/unPurchaseable.wav", GetTree().CurrentScene);
			}
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
