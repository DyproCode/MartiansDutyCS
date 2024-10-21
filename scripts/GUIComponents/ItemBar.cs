using Godot;
using System;
using MartiansDutyCS.scripts.Items;
using MartiansDutyCS.scripts.Systems;
using EventHandler = MartiansDutyCS.scripts.Systems.EventHandler;

public partial class ItemBar : Control
{
    private HBoxContainer _boxContainer;
    private PackedScene _itemUiPackedScene = (PackedScene)ResourceLoader.Load("res://scenes/Screens/GUIComponents/item_ui.tscn");
 
    public override void _Ready()
    {
        _boxContainer = GetNode<HBoxContainer>("HBoxContainer");
        EventHandler.GetInstance().Connect(EventHandler.SignalName.ItemAcquire, new Callable(this, nameof(OnItemAcquired)));
    }

    public void OnItemAcquired(Item item)
    {
        if (!Player.GetInstance().hasItem(item))
        {
            var itemUiNode = _itemUiPackedScene.Instantiate();
            var itemUi = itemUiNode as ItemUi; 
            itemUi!.Initialize(item);
            _boxContainer.AddChild(itemUi);
        }
    }
}
