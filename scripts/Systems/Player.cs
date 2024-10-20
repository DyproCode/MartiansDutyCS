namespace MartiansDutyCS.scripts.Systems;

public class Player
{
    //Game Attributes
    public int Money = 0;
    public float Speed = 150;
    public int Damage = 1;
    public int MaxHealth = 5;
    public int CurrentHealth;
    
    private static Player _player = null;

    private Player()
    {
        CurrentHealth = MaxHealth;
    }

    public static Player GetInstance()
    {
        if (_player == null)
        {
            _player = new Player();
        }

        return _player;
    }
}