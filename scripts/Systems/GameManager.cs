using Godot;

namespace MartiansDutyCS.scripts.Systems;

public partial class GameManager : Node
{
    private static GameManager _gameManager = null;
    private int _round = 1;
    private GameManager() { }

    public static GameManager GetInstance()
    {
        if (_gameManager == null)
        {
            _gameManager = new GameManager();
        }

        return _gameManager;
    }
    
    public void IncreaseRound()
    {
        _round++;
        EventHandler.GetInstance().EmitSignal(EventHandler.SignalName.EndOfRound);
    }

    public int GetRound()
    {
        return _round;
    }
}