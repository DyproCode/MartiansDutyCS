using Godot;

namespace MartiansDutyCS.scripts.Entities.Player.PlayerStates;

public partial class DashingState : Node, IState
{
    private PlayerScene _player;
    private const int DASH_TIME = 10;
    private int _currentDashTime;
    private float _dashSpeed = 1000;
    private Vector2 _dashDir = Vector2.Zero;

    private bool _canRoll = true;
    private Timer _rollTimer;
    
    public override void _Ready()
    {
        _rollTimer = GetNode<Timer>("RollTimer");
        _player = GetParent().GetParent() as PlayerScene;
    }
    
    public void Enter()
    {
        _player._sprite.Animation = "dashing";
        _rollTimer.Start();
        _canRoll = false;
        _dashDir = Vector2.FromAngle(_player._sprite.Rotation);
    }

    public void Exit()
    {
    }

    public void PhysicsUpdate()
    {
        if (_currentDashTime <= DASH_TIME)
        {
            _currentDashTime++;
            _player.Velocity = _dashSpeed * _dashDir;
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
    
    private void _on_roll_timer_timeout()
    {
        _canRoll = true;
    }
}