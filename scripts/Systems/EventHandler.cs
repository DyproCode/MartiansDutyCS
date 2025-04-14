using Godot;
using MartiansDutyCS.scripts.Entities;
using MartiansDutyCS.scripts.Items;

namespace MartiansDutyCS.scripts.Systems;


public partial class EventHandler : Node
{
    private static EventHandler _eventHandler = null;

    [Signal]
    public delegate void EnemyDiesEventHandler(BaseEnemy enemy);

    [Signal]
    public delegate void EndOfRoundEventHandler();
    
    [Signal]
    public delegate void StartOfRoundEventHandler();

    [Signal]
    public delegate void ItemSelectedEventHandler(Item selectedItem);

    [Signal]
    public delegate void ItemAcquireEventHandler(Item acquiredItem);

    [Signal]
    public delegate void OnPlayerMaxHealthIncreaseEventHandler();
    
    [Signal]
    public delegate void OnPlayerHealEventHandler();
    
    [Signal]
    public delegate void OnHitEventHandler();
    
    private EventHandler()
    {
        Connect(SignalName.EnemyDies, new Callable(this, nameof(OnEnemyDies)));
        Connect(SignalName.ItemAcquire, new Callable(this, nameof(OnItemAcquire)));
        Connect(SignalName.OnHit, new Callable(this, nameof(OnOnHit)));
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

        foreach (var item in Player.GetInstance().GetItems())
        {
            foreach (var trigger in item.Triggers)
            {
                if (trigger.TriggerType == TriggerType.Die)
                {
                    trigger.Execute();
                }
            }
        }
    }

    private void OnItemAcquire(Item item)
    {
        foreach (var trigger in item.Triggers)
        {
            if (trigger.TriggerType == TriggerType.OnAcquire)
            {
                trigger.Execute();
            }
        }
    }

    private void OnOnHit()
    {
        foreach (var item in Player.GetInstance().GetItems())
        {
            foreach (var trigger in item.Triggers)
            {
                if (trigger.TriggerType == TriggerType.OnHit)
                {
                    trigger.Execute();
                }
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