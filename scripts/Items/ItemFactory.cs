using System.Collections.Generic;
using Godot;
using MartiansDutyCS.scripts.Items.ItemImplementations;

namespace MartiansDutyCS.scripts.Items;

public class ItemFactory
{
    private ItemDirector _itemDirector = new ItemDirector();
    private static ItemFactory _itemFactory;
    private static List<string> _itemNames;

    private ItemFactory()
    {
        _itemNames = new List<string>
        {
          "SyringeClamp"  
        };
    }

    public static ItemFactory GetInstance()
    {
        if (_itemFactory == null)
        {
            _itemFactory = new ItemFactory();
        }

        return _itemFactory;
    }
    
    public Item CreateSpecificItem(string itemName)
    {
        if (itemName == "SyringeClamp")
        {
            return _itemDirector.BuildItem(new SyringeClamp());
        }
        
        return null;
    }

    public List<Item> CreateXItems(int numItems)
    {
        List<Item> randomItems = new List<Item>();

        for (int i = 0; i < numItems; i++)
        {
            int randomIndex = GD.RandRange(0, _itemNames.Count - 1);
            
            randomItems.Add(CreateSpecificItem(_itemNames[randomIndex]));
        }
        
        return randomItems;
    }
}