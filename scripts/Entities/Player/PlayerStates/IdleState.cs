using Godot;

namespace MartiansDutyCS.scripts.Entities.Player.PlayerStates;

public partial class IdleState : Node, IState
{
    private PlayerScene _player;

    public override void _Ready()
    {
        _player = GetParent().GetParent() as PlayerScene;
    }
    
    public void Enter()
    {
        _player._sprite.Animation = "idle";
    }

    public void Exit()
    {
    }

    public void PhysicsUpdate()
    {
        if (Input.GetVector("LEFT", "RIGHT", "UP", "DOWN") != Vector2.Zero)
        {
            _player.SwitchState("walking");
        }

        if (Input.IsActionJustPressed("DASH") && _player._canRoll)
        {
            _player.SwitchState("dashing");
        }
        
        if (Input.IsActionPressed("SHOOT"))
        {
            _player.Shoot();
        }
    }

    public void Update()
    {
        
    }
}