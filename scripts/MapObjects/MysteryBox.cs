using Godot;
using System;
using MartiansDutyCS.scripts.Items;
using MartiansDutyCS.scripts.Systems;

public partial class MysteryBox : StaticBody2D
{
	private Area2D _purchaseArea;
	private Label _purchaseLabel;
	private PlayerScene _player;
	private int _price = 2000;
	
	public override void _Ready()
	{
		_purchaseArea = GetNode<Area2D>("PurchaseArea");
		_purchaseLabel = GetNode<Label>("PurchaseLabel");
		_player = GetParent().GetParent().GetNode<PlayerScene>("Player");
		_purchaseLabel.Text = "Get a random item for $" + _price;
	}
	public override void _Process(double delta)
	{
		if (_purchaseArea.OverlapsArea(_player.HitArea) && Input.IsActionJustPressed("INTERACT") && Player.GetInstance().Money >= _price)
		{
			Player.GetInstance().Money -= _price;
			Player.GetInstance().GivePlayerItem(ItemFactory.GetInstance().CreateXItems(1)[0]);
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
