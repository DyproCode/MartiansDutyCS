using Godot;
using System;
using MartiansDutyCS.scripts.Items;
using EventHandler = MartiansDutyCS.scripts.Systems.EventHandler;

public partial class ItemSlot : Control
{
    private Item _item = null;
    private TextureRect _itemTexture;
    private Label _description;
    private Label _itemName;
    public void Initialize(Item item)
    {
        if (_item != null)
        {
            _item.QueueFree();
            _item = null;
        }
        
        _item = item;
        _itemTexture.SetTexture(_item.Texture);
        _itemName.SetText(_item.ItemName);
        _description.SetText(_item.Description);
    }
    
    public override void _Ready()
    {
        _itemTexture = GetNode<TextureRect>("ItemTexture");
        _itemName = GetNode<Label>("ItemName");
        _description = GetNode<Label>("Description");
    }
    
    public void _on_button_pressed()
    {
        EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.ItemSelected, _item);
    }

    public override void _ExitTree()
    {
        if (_item != null)
        {
            _item.QueueFree();
        }
    }
}
