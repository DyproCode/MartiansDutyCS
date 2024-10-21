using System.Collections.Generic;
using MartiansDutyCS.scripts.Items;

namespace MartiansDutyCS.scripts.Systems;

public class Player
{
    //Game Attributes
    public int Money = 0;
    public float Speed = 150;
    public int Damage = 1;
    public int MaxHealth = 5;
    public int CurrentHealth;
    private List<Item> _items = new List<Item>();
    
    private static Player _player = null;
    
    private Player()
    {
        CurrentHealth = MaxHealth;
    }

    public static Player GetInstance()
    {
        if (_player == null)
        {
            _player = new Player();
        }

        return _player;
    }

    public void GivePlayerItem(Item item)
    {

        EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.ItemAcquire, item);
        _items.Add(item);
    }
}