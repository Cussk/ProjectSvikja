namespace Core.StateMachines.Player
{
    public abstract class PlayerBaseState : BaseState
    {
        protected PlayerStateMachine playerStateMachine;

        public PlayerBaseState(PlayerStateMachine playerStateMachine)
        {
            this.playerStateMachine = playerStateMachine;
        }
    }
}
