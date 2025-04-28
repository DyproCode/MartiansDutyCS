using System.Collections.Generic;
using System.Linq;
using Godot;
using MartiansDutyCS.scripts.Items.ItemImplementations;

namespace MartiansDutyCS.scripts.Items;

public class ItemFactory
{
    private ItemDirector _itemDirector = new ItemDirector();
    private static ItemFactory _itemFactory;
    private static List<string> _itemNames;
    private static List<string> _choasItemNames;

    private ItemFactory()
    {
        _itemNames = new List<string>
        {
          "SyringeClamp",
          "BulletProofVest",
          "LocalCurrency",
          "RapidFire",
          "GremloidSkull",
          "GremloidFoot",
          "LaserAttachment",
          "VampRounds",
          "GremloidHand",
          "HoloWatch",
          "Gremloidium",
          "InterestOrb",
          "GremloidOoze",
          "HeavyRounds",
          "HardenedGremloidium",
          "GremloidEar",
          "FourLeafClover"
        };

        _choasItemNames = new List<string>
        {
            "ChaosHourGlass",
            "GoldenClover"
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
        else if (itemName == "BulletProofVest")
        {
            return _itemDirector.BuildItem(new BulletProofVest());
        }
        else if (itemName == "LocalCurrency")
        {
            return _itemDirector.BuildItem(new LocalCurrency());
        }
        else if (itemName == "RapidFire")
        {
            return _itemDirector.BuildItem(new RapidFire());
        }
        else if (itemName == "GremloidSkull")
        {
            return _itemDirector.BuildItem(new GremloidSkull());
        }
        else if (itemName == "GremloidFoot")
        {
            return _itemDirector.BuildItem(new GremloidFoot());
        }
        else if (itemName == "LaserAttachment")
        {
            return _itemDirector.BuildItem(new LaserAttachment());
        }
        else if (itemName == "VampRounds")
        {
            return _itemDirector.BuildItem(new VampRounds());
        }
        else if (itemName == "GremloidHand")
        {
            return _itemDirector.BuildItem(new GremloidHand());
        }
        else if (itemName == "HoloWatch")
        {
            return _itemDirector.BuildItem(new HoloWatch());
        }
        else if (itemName == "Gremloidium")
        {
            return _itemDirector.BuildItem(new Gremloidium());
        }
        else if (itemName == "InterestOrb")
        {
            return _itemDirector.BuildItem(new InterestOrb());
        }
        else if (itemName == "GremloidOoze")
        {
            return _itemDirector.BuildItem(new GremloidOoze());
        }
        else if (itemName == "HeavyRounds")
        {
            return _itemDirector.BuildItem(new HeavyRounds());
        }
        else if (itemName == "HardenedGremloidium")
        {
            return _itemDirector.BuildItem(new HardenedGremloidium());
        }
        else if (itemName == "GremloidEar")
        {
            return _itemDirector.BuildItem(new GremloidEar());
        }
        else if (itemName == "FourLeafClover")
        {
            return _itemDirector.BuildItem(new FourLeafClover());
        }
        else if (itemName == "GoldenClover")
        {
            return _itemDirector.BuildItem(new GoldenClover());
        }
        else if (itemName == "ChoasHourGlass")
        {
            return _itemDirector.BuildItem(new ChoasHourGlass());
        }
        
        return null;
    }

    public List<Item> CreateXItems(int numItems)
    {
        List<Item> randomItems = new List<Item>();
        List<string> itemPool = _itemNames.ToList();
       
        for (int i = 0; i < numItems; i++)
        {
            int randomIndex = GD.RandRange(0, itemPool.Count - 1);
            
            randomItems.Add(CreateSpecificItem(itemPool[randomIndex]));
            itemPool.RemoveAt(randomIndex);
        }
        
        return randomItems;
    }

    public Item CreateChaosItem()
    {
        int randomIndex = GD.RandRange(0, _choasItemNames.Count - 1);
        return CreateSpecificItem(_choasItemNames[randomIndex]);
    }
}