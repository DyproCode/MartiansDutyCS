using System.Collections.Generic;
using System.Net.Mime;
using Godot;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Items;

public partial class BaseItem : Node
{
    public List<Trigger> Triggers = new List<Trigger>();
    public string Name;
    public int Cost;
    public string Description;
    public Texture2D Texture;
}