using Godot;

namespace MartiansDutyCS.scripts.Systems;

public class AssetLoader
{
    private static AssetLoader _assetLoader = null;
    
    //ITEM TEXTURES
    public Texture2D ITEM_BRAINJAR;
    public Texture2D ITEM_CHESTPLATE;
    public Texture2D ITEM_EXPLOSIVEROUNDS;
    public Texture2D ITEM_GALAXYHOURGLASS;
    public Texture2D ITEM_GREMLOIDEAR;
    public Texture2D ITEM_GREMLOIDFOOT;
    public Texture2D ITEM_GREMLOIDHAND;
    public Texture2D ITEM_GREMLOIDSKULL;
    public Texture2D ITEM_GREMLOIDTEETH;
    public Texture2D ITEM_HOLOWATCH;
    public Texture2D ITEM_LASERATTACHMENT;
    public Texture2D ITEM_OCTOPUSKEYCHAIN;
    public Texture2D ITEM_OOZEDIGLET;
    public Texture2D ITEM_ORB;
    public Texture2D ITEM_RAPIDFIRE;
    public Texture2D ITEM_ROCKCRYSTAL;
    public Texture2D ITEM_ROCKCRYSTALPURPLE;
    public Texture2D ITEM_SYRINGECLAMP;
    public Texture2D ITEM_TENTACLESIGNET;
    public Texture2D ITEM_VAMPROUNDS;
    public Texture2D ITEM_CLOVER;
    public Texture2D ITEM_GOLDENCLOVER;
    
    private AssetLoader()
    {
        ITEM_BRAINJAR = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_BrainJar.png");
        ITEM_CHESTPLATE = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_Chestplate.png");
        ITEM_EXPLOSIVEROUNDS = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_ExplosiveRoundsWIP.png");
        ITEM_GALAXYHOURGLASS = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_GalaxyHourglass.png");
        ITEM_GREMLOIDEAR = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_GremloidEar.png");
        ITEM_GREMLOIDFOOT = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_GremloidFoot.png");
        ITEM_GREMLOIDHAND = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_GremloidHand.png");
        ITEM_GREMLOIDSKULL = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_GremloidSkull.png");
        ITEM_GREMLOIDTEETH = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_GremloidTeeth.png");
        ITEM_HOLOWATCH = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_HoloWatch.png");
        ITEM_LASERATTACHMENT = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_LaserAttachment.png");
        ITEM_OCTOPUSKEYCHAIN = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_OctopusKeychain.png");
        ITEM_OOZEDIGLET = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_OozeDiglet.png");
        ITEM_ORB = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_Orb.png");
        ITEM_RAPIDFIRE = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_RapidFire.png");
        ITEM_ROCKCRYSTAL = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_RockCrystal.png");
        ITEM_ROCKCRYSTALPURPLE = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_RockCrystalPurple.png");
        ITEM_SYRINGECLAMP = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_SyringeClamp.png");
        ITEM_TENTACLESIGNET = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_TentacleSignet.png");
        ITEM_VAMPROUNDS = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_VampRoundsWIP.png");
        ITEM_CLOVER = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_Clover.png");
        ITEM_GOLDENCLOVER = (Texture2D)GD.Load("res://assets/sprites/Item Icons/MD_GoldenClover.png");

    }

    public static AssetLoader GetInstance()
    {
        if (_assetLoader == null)
        {
            _assetLoader = new AssetLoader();
        }

        return _assetLoader;
    }
}