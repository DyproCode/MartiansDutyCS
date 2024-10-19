using Godot;

namespace MartiansDutyCS.scripts.Systems;

public partial class GameManager : Node
{
    private static GameManager _gameManager = null;
    private GameManager() { }

    public static GameManager GetInstance()
    {
        if (_gameManager == null)
        {
            _gameManager = new GameManager();
        }

        return _gameManager;
    }
}