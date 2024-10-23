using Godot;

namespace MartiansDutyCS.scripts.Entities.Player.PlayerStates;

public partial class WalkingState : Node, IState
{
    private PlayerScene _player;

    public override void _Ready()
    {
        _player = GetParent().GetParent() as PlayerScene;
    }

    public void Enter()
    {
        _player._sprite.Animation = "walking";
    }

    public void Exit()
    {
    }
    
    public void PhysicsUpdate()
    {
        var dir = Input.GetVector("LEFT", "RIGHT", "UP", "DOWN");
        _player.Velocity = dir * Systems.Player.GetInstance().Speed;
        
        if (dir == Vector2.Zero)
        {
            _player.SwitchState("idle");
        }
        
        if (Input.IsActionJustPressed("DASH") && _player._canRoll)
        {
            _player.SwitchState("dashing");
        }
    }

    public void Update()
    {
    }
}