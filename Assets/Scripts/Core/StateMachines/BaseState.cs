namespace Core.StateMachines
{
    public abstract class BaseState
    {
        public abstract void Enter();
        public abstract void Tick(float deltaTime);
        public abstract void Exit();
    }
}
