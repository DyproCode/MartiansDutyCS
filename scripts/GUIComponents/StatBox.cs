using Godot;
using System;

public partial class StatBox : Control
{
    public TextureRect IconSprite;
    [Export] private Texture2D Text;
    private Label _statLabel;
    
    public override void _Ready()
    {
        IconSprite = GetNode<TextureRect>("HBoxContainer/TextureRect");
        _statLabel = GetNode<Label>("HBoxContainer/StatValueLabel");
        IconSprite.Texture = Text;
    }

    public void SetValue(string value)
    {
        _statLabel.Text = value;
    }
    
}
