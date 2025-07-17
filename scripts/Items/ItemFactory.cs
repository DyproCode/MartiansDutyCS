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
          "Syringe Clamp",
          "Bullet Proof Vest",
          "Local Currency",
          "Rapid Fire",
          "Gremloid Skull",
          "Gremloid Foot",
          "Laser Attachment",
          "Vamp Rounds",
          "Gremloid Hand",
          "Holo Watch",
          "Gremloidium",
          "Interest Orb",
          "Gremloid Ooze",
          "Heavy Rounds",
          "Hardened Gremloidium",
          "Gremloid Ear",
          "Four Leaf Clover"
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
        if (itemName == "Syringe Clamp")
        {
            return _itemDirector.BuildItem(new SyringeClamp());
        }
        else if (itemName == "Bullet Proof Vest")
        {
            return _itemDirector.BuildItem(new BulletProofVest());
        }
        else if (itemName == "Local Currency")
        {
            return _itemDirector.BuildItem(new LocalCurrency());
        }
        else if (itemName == "Rapid Fire")
        {
            return _itemDirector.BuildItem(new RapidFire());
        }
        else if (itemName == "Gremloid Skull")
        {
            return _itemDirector.BuildItem(new GremloidSkull());
        }
        else if (itemName == "Gremloid Foot")
        {
            return _itemDirector.BuildItem(new GremloidFoot());
        }
        else if (itemName == "Laser Attachment")
        {
            return _itemDirector.BuildItem(new LaserAttachment());
        }
        else if (itemName == "Vamp Rounds")
        {
            return _itemDirector.BuildItem(new VampRounds());
        }
        else if (itemName == "Gremloid Hand")
        {
            return _itemDirector.BuildItem(new GremloidHand());
        }
        else if (itemName == "Holo Watch")
        {
            return _itemDirector.BuildItem(new HoloWatch());
        }
        else if (itemName == "Gremloidium")
        {
            return _itemDirector.BuildItem(new Gremloidium());
        }
        else if (itemName == "Interest Orb")
        {
            return _itemDirector.BuildItem(new InterestOrb());
        }
        else if (itemName == "Gremloid Ooze")
        {
            return _itemDirector.BuildItem(new GremloidOoze());
        }
        else if (itemName == "Heavy Rounds")
        {
            return _itemDirector.BuildItem(new HeavyRounds());
        }
        else if (itemName == "Hardened Gremloidium")
        {
            return _itemDirector.BuildItem(new HardenedGremloidium());
        }
        else if (itemName == "Gremloid Ear")
        {
            return _itemDirector.BuildItem(new GremloidEar());
        }
        else if (itemName == "Four Leaf Clover")
        {
            return _itemDirector.BuildItem(new FourLeafClover());
        }
        else if (itemName == "Golden Clover")
        {
            return _itemDirector.BuildItem(new GoldenClover());
        }
        else if (itemName == "Chaos Hour Glass")
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