using Godot;
using MartiansDutyCS.scripts.Entities;

namespace MartiansDutyCS.scripts.Systems;


public partial class EventHandler : Node
{
    private static EventHandler _eventHandler = null;

    [Signal]
    public delegate void EnemyDiesEventHandler(BaseEnemy enemy);
    
    private EventHandler()
    {
        Connect(SignalName.EnemyDies, new Callable(this, nameof(OnEnemyDies)));
    }
    
    private void OnEnemyDies(BaseEnemy enemy)
    {
        foreach (var trigger in enemy.Triggers)
        {
            if (trigger.TriggerType == TriggerType.Die)
            {
                trigger.Execute();  
            }
        }
    }
    
    public static EventHandler GetInstance()
    {
        if (_eventHandler == null)
        {
            _eventHandler = new EventHandler();
        }

        return _eventHandler;
    }
}