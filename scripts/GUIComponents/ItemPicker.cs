using System.Collections.Generic;
using Godot;
using MartiansDutyCS.scripts.Items;
using MartiansDutyCS.scripts.Systems;

public partial class ItemPicker : Control
{
    private ItemSlot _itemSlot1;
    private ItemSlot _itemSlot2;
    private ItemSlot _itemSlot3;
    public override void _Ready()
    {
        _itemSlot1 = GetNode<ItemSlot>("ItemSelectionBox/ItemSlot1");
        _itemSlot2 = GetNode<ItemSlot>("ItemSelectionBox/ItemSlot2");
        _itemSlot3 = GetNode<ItemSlot>("ItemSelectionBox/ItemSlot3");
        
        EventHandler.GetInstance().Connect(EventHandler.SignalName.ItemSelected,
            new Callable(this, nameof(OnItemSelected)));
    }

    public void SetUpNewSelection()
    {
        List<Item> itemSelections = ItemFactory.GetInstance().CreateXItems(3);
        _itemSlot1.Initialize(itemSelections[0]);
        _itemSlot2.Initialize(itemSelections[1]);
        _itemSlot3.Initialize(itemSelections[2]);
    }

    public void OnItemSelected(Item selectedItem)
    {
        Player.GetInstance().GivePlayerItem(selectedItem);
        Hide();
    }
}