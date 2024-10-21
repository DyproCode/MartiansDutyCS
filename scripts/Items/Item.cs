using System.Collections.Generic;
using System.Net.Mime;
using Godot;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items;

public partial class Item : Node
{
    public List<Trigger> Triggers = new List<Trigger>();
    public string ItemName;
    public int Cost;
    public string Description;
    public Texture2D Texture;
    public int Amount = 1;

    public Item()
    {
        base.Name = "Item";
    }
}