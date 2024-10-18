namespace MartiansDutyCS.scripts.Systems;

public class GameManager
{
    private GameManager _gameManager = null;
    private GameManager() { }

    public GameManager GetInstance()
    {
        if (_gameManager == null)
        {
            _gameManager = new GameManager();
        }

        return _gameManager;
    }
}