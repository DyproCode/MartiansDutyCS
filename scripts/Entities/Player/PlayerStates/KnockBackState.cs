using Godot;

namespace MartiansDutyCS.scripts.Entities.Player.PlayerStates;

public partial class KnockBackState : Node, IState
{
    private PlayerScene _player;
    private const int KNOCK_BACK_TIME = 2;
    private int _currentDashTime;
    private float _KnockBackSpeed = 1000;
    private Vector2 _dashDir = Vector2.Zero;
    
    public override void _Ready()
    {
        _player = GetParent().GetParent() as PlayerScene;
    }
    
    public void Enter()
    {
        _player._sprite.Animation = "walking";
        _dashDir = Vector2.FromAngle(_player._sprite.Rotation);
    }

    public void Exit()
    {
    }

    public void PhysicsUpdate()
    {
        if (_currentDashTime <= KNOCK_BACK_TIME)
        {
            _currentDashTime++;
            _player.Velocity = _KnockBackSpeed * -_dashDir;
        }
        else
        {
            _currentDashTime = 0;
            _player.SwitchState("walking");
        }
    }

    public void Update()
    {
        
    }
}