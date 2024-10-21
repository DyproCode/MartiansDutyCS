using Godot;
using System;
using MartiansDutyCS.scripts.Items;

public partial class ItemUi : Control
{
    private TextureRect _itemTexture;
    private Label _amountLabel;
    private Item _item;

    public override void _Ready()
    {
        _itemTexture = GetNode<TextureRect>("ItemTexture");
        _amountLabel = GetNode<Label>("Amount");
        
        _itemTexture.SetTexture(_item.Texture);
        
        if (_item.Amount > 1)
        {
            _amountLabel.SetText(_item.Amount.ToString());
        }
        else
        {
            _amountLabel.SetText("");
        }
    }

    public void Initialize(Item item)
    {
        _item = item;
    }

    public override void _ExitTree()
    {
        if (_item != null)
        {
            _item.QueueFree();   
        }
    }
}
