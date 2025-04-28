using System;
using Godot;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Effects;

public class EffectIncreasePlayerMoney : IEffect
{
    private int _amount = 0;
    private string _increaseType = "";
    private double _increasePercent = 0;

    public EffectIncreasePlayerMoney(int amount)
    {
        _amount = amount;
    }

    public EffectIncreasePlayerMoney(string increaseType, double percentage = 0.0)
    {
        _increaseType = increaseType;
        _increasePercent = percentage;
    }
    public void Execute()
    {
        if (_increaseType == "Interest")
        {
            var goldEarned = (int)(Player.GetInstance().Money * _increasePercent);
            Player.GetInstance().Money += goldEarned; 
        }
        
        Player.GetInstance().Money += _amount;
    }
}