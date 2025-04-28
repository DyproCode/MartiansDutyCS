using System.Collections.Generic;
using Godot;
using MartiansDutyCS.scripts.DataClasses;

namespace MartiansDutyCS.scripts.Systems;

public partial class GameManager : Node
{
    private static GameManager _gameManager = null;
    private int _round = 0;
    private List<int> _unlockedSections =  new();
    private int _gremloidsKilled = 0;
    public GameSessionData GameSessionData { get; set; } = new GameSessionData();

    private GameManager()
    {
        EventHandler.GetInstance()
            .Connect(EventHandler.SignalName.StartOfRound, new Callable(this, nameof(OnStartOfRound)));
        _unlockedSections.Add(1);
    }

    public void ResetGame()
    {
        _round = 0;
        _unlockedSections.Clear();
        _unlockedSections.Add(1);
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

    public List<int> GetSections()
    {
        return _unlockedSections;
    }

    public void UnlockSection(int section)
    {
        _unlockedSections.Add(section);
    }

    public void OnStartOfRound()
    {
        _round++;
    }

    public void IncrementGremloidsKilled()
    {
        _gremloidsKilled++;
    }

    public int GetGremloidsKilled()
    {
       return _gremloidsKilled;
    }
}