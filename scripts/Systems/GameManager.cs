using Godot;
using MartiansDutyCS.scripts.DataClasses;

namespace MartiansDutyCS.scripts.Systems;

public partial class GameManager : Node
{
    private static GameManager _gameManager = null;
    private int _round = 0;
    private int _section = 1;
    public GameSessionData GameSessionData { get; set; } = new GameSessionData();

    private GameManager()
    {
        EventHandler.GetInstance()
            .Connect(EventHandler.SignalName.StartOfRound, new Callable(this, nameof(OnStartOfRound)));
    }

    public void ResetGame()
    {
        _round = 0;
        _section = 1;
    }

    public static GameManager GetInstance()
    {
        if (_gameManager == null)
        {
            _gameManager = new GameManager();
        }

        return _gameManager;
    }
    
    public int GetRound()
    {
        return _round;
    }

    public void SetRound(int round)
    {
        _round = round;
    }

    public int GetSection()
    {
        return _section;
    }

    public void IncreaseSection()
    {
        _section++;
    }

    public void OnStartOfRound()
    {
        _round++;
    }
}