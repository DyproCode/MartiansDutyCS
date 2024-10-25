using Godot;
using System;
using MartiansDutyCS.scripts.Systems;

public partial class StatsHud : Control
{
    private StatBox _healthBox;
    private StatBox _damageBox;
    private StatBox _critBox;
    private StatBox _pierceBox;
    private StatBox _luckBox;
    private StatBox _fireRateBox;
    private StatBox _moveSpeedBox;
    private StatBox _armourBox;

    public override void _Ready()
    {
        _healthBox = GetNode<StatBox>("IconContainer/LeftSideContainer/HealthBox");
        _damageBox = GetNode<StatBox>("IconContainer/LeftSideContainer/DamageBox");
        _critBox = GetNode<StatBox>("IconContainer/LeftSideContainer/CritDamageBox");
        _pierceBox = GetNode<StatBox>("IconContainer/LeftSideContainer/PierceBox");
        _luckBox = GetNode<StatBox>("IconContainer/RightSideContainer/LuckBox");
        _fireRateBox = GetNode<StatBox>("IconContainer/RightSideContainer/FireRateBox");
        _moveSpeedBox = GetNode<StatBox>("IconContainer/RightSideContainer/MoveSpeedBox");
        _armourBox = GetNode<StatBox>("IconContainer/RightSideContainer/ArmourBox");

    }

    public override void _Process(double delta)
    {
        _healthBox.SetValue(Player.GetInstance().MaxHealth.ToString());
        _damageBox.SetValue(Player.GetInstance().Damage.ToString());
        _critBox.SetValue(Player.GetInstance().CritDamage * 100 + "%");
        _pierceBox.SetValue(Player.GetInstance().Pierce.ToString());
        _luckBox.SetValue(Player.GetInstance().Luck.ToString());
        _fireRateBox.SetValue(Math.Round(Player.GetInstance().AttackSpeed, 2).ToString());
        _moveSpeedBox.SetValue(Player.GetInstance().Speed.ToString());
        _armourBox.SetValue(Player.GetInstance().Armour.ToString());
    }
}
