using System.Collections.Generic;
using System.Linq;
using MartiansDutyCS.scripts.Items;

namespace MartiansDutyCS.scripts.Systems;

public class Player
{
    //Game Attributes
    public int Money = 0;
    
    public float Speed = 150;
    public double AttackSpeed = 0.35;
    public int Damage = 20;
    public int MaxHealth = 100;
    public int Luck = 0;
    public int Pierce = 0;
    public int Armour = 0;
    public double CritDamage = 1.25;
    
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

        if (_items.Any(i => i.ItemName == item.ItemName))
        {
            _items.Find(i => i.ItemName == item.ItemName).Amount++;
        }
        else
        {
            _items.Add(item);
        }
    }

    public bool hasItem(string itemName)
    {
        return _items.Any(i => i.ItemName == itemName);
    }

    public bool hasItem(Item item)
    {
        return _items.Any(i => i.ItemName == item.ItemName);
    }

    public List<Item> GetItems()
    {
        return _items;
    }
    
}