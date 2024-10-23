using Godot;

namespace MartiansDutyCS.scripts.Entities;

public interface IState
{
    public void Enter();
    public void Exit();
    public void PhysicsUpdate();
    public void Update();
}