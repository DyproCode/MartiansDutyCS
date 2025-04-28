using Godot;
using MartiansDutyCS.scripts.Systems;

namespace MartiansDutyCS.scripts.Entities.Player.PlayerStates;

public partial class DashingState : Node, IState
{
    private PlayerScene _player;
    private const int DASH_TIME = 10;
    private int _currentDashTime;
    private float _dashSpeed = 1000;
    private Vector2 _dashDir = Vector2.Zero;
    
    public override void _Ready()
    {
        _player = GetParent().GetParent() as PlayerScene;
    }
    
    public void Enter()
    {
        _player._sprite.Animation = "dashing";
        _player._rollTimer.Start();
        _player._canRoll = false;
        _dashDir = Input.GetVector("LEFT", "RIGHT", "UP", "DOWN");
        AudioManager.GetInstance().PlaySound("res://assets/sounds/teleport.wav", Systems.Player.GetInstance().GetPlayerScene(), volume: -9);
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
}